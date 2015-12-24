using UnityEngine;
using System.Collections;

public class ChoixDebut : MonoBehaviour {
	private Animator ani;
	private bool b;
	private bool c;
	private bool d;
	private bool e;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
		b = false;
		c = false;
		e = false;
		d = false;
	}
	
	// Update is called once per frame
	void Update () {
if (e == false) {
			if (Input.GetKeyUp ("n")) {
				ani.SetInteger ("Choix", 1);
				Debug.Log ("Non");
				e = true;
			}
			if (Input.GetKeyUp ("o")) {
				if (b == false) {
					ani.SetInteger ("Choix", 2);
					Debug.Log ("Oui");
					b = true;
				} else {
					if (c == false) {
						ani.SetInteger ("Choix", 3);
						Debug.Log ("Oui");
						c = true;
					} else {
						ani.SetInteger ("Choix", 4);
						Debug.Log ("Oui Derniere");
						e = true;

					}

			

				}

			}
		} else if (d == false) {
			if (Input.GetKeyUp ("n")) {
				ani.SetInteger ("Choix", 6);
				Debug.Log ("Non");
				d = true;
			}
			if (Input.GetKeyUp ("o")) {
				ani.SetInteger ("Choix", 5);
				Debug.Log ("Oui");
			}
		} else {
			if (Input.GetKeyUp ("n"))
				ani.SetInteger ("Choix", 7);
			if (Input.GetKeyUp ("o"))
				ani.SetInteger ("Choix", 7);
		}


	}
}
