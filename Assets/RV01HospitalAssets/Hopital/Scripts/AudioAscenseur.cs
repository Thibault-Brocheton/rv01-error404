using UnityEngine;
using System.Collections;

public class AudioAscenseur : MonoBehaviour {

	public AudioSource ascenseur;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		ascenseur.Play ();
	}

	void OnTriggerExit(Collider other) {
		ascenseur.Stop ();
	}
}
