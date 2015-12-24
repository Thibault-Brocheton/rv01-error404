using UnityEngine;
using System.Collections;

public class CourseRené : MonoBehaviour {
	Rigidbody rb;
	private float startY;
	private float startX;
	private float startZ;
	// Use this for initialization
	void Start () {
		startX = transform.eulerAngles.x;
		startY = transform.eulerAngles.y;
		startZ = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(startX,startY,startZ);
		rb = GetComponent<Rigidbody>();
		rb.velocity = rb.velocity*1.005f;


	}
}
