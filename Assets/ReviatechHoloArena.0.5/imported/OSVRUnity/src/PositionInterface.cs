/// OSVR-Unity Connection
///
/// http://sensics.com/osvr
///
/// <copyright>
/// Copyright 2014 Sensics, Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///     http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </copyright>

#define THREAD_ACTIVATED

using System;
using UnityEngine;

namespace OSVR
{
    namespace Unity
    {
        /// <summary>
        /// Position interface: continually (or rather, when OSVR updates) updates its position based on the incoming tracker data.
        ///
        /// Attach to a GameObject that you'd like to have updated in this way.
        /// </summary>
        public class PositionInterface : MonoBehaviour
        {
            /// <summary>
            /// The interface path you want to connect to.
            /// </summary>
            public string path;

            private OSVR.ClientKit.Interface iface;
            private OSVR.ClientKit.PositionCallback cb;

            // Use this for initialization
            void Start()
            {
                if (0 == path.Length)
                {
                    Debug.LogError("Missing path for PositionInterface " + gameObject.name);
                    return;
                }

                iface = OSVR.Unity.ClientKit.instance.context.getInterface(path);
                cb = new OSVR.ClientKit.PositionCallback(callback);
                iface.registerCallback(cb, IntPtr.Zero);
            }
			
#if THREAD_ACTIVATED
			private Vector3 data;
			private object LOCKER = new object();
			private System.Threading.AutoResetEvent NEW_DATA_EVENT = new System.Threading.AutoResetEvent(false);
#endif
            private void callback(IntPtr userdata, ref OSVR.ClientKit.TimeValue timestamp, ref OSVR.ClientKit.PositionReport report)
            {
#if THREAD_ACTIVATED
				var temp = Math.ConvertPosition(report.xyz);
				lock (LOCKER)
				{
					data = temp;
				}
				NEW_DATA_EVENT.Set ();
#else
                transform.localPosition = Math.ConvertPosition(report.xyz);
#endif
            }
			
#if THREAD_ACTIVATED
			void Update()
			{
				if (NEW_DATA_EVENT.WaitOne(0))
				{
					lock (LOCKER)
					{
						transform.localPosition = data;
					}
				}
			}
#endif

            void OnDestroy()
            {
                iface = null;
            }
        }
    }
}
