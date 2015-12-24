using UnityEngine;
using System.Collections;

public class RencontreMed : MonoBehaviour {
	public GameObject Handy;
	public GameObject salle;
	private Animator ani;
	private AudioSource aud;
	private AudioSource aud2;
	private bool rep;
	private bool rep2;
	// Use this for initialization
	void Start () {
		aud = GetComponents <AudioSource>() [1];
		aud2 = GetComponents <AudioSource>() [2];
		ani = GetComponent<Animator>();
		ani.SetBool ("Medproche", false);
		rep = true;
		rep2 = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (distance(transform.position, salle.transform.position) < 10)
		{
			if (distance(transform.position, Handy.transform.position) < 20)
			{
				if (rep)
				{
					Debug.Log ("OK");
					ani.SetBool ("Medproche", true);
					aud.Play ();
					rep = false;
				}
			}

			if (distance(transform.position, Handy.transform.position) < 70)
			{
				if (rep2)
				{

					aud2.Play ();
					rep2= false;
				}
			}
		}

	}

	private float distance(Vector3 v1, Vector3 v2)
	{
		return Mathf.Sqrt(Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.y - v2.y), 2) + Mathf.Pow((v1.z - v2.z), 2));
	}
}
