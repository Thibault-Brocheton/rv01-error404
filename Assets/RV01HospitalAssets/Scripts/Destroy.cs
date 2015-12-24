using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public GameObject docteur;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (distance(transform.position, docteur.transform.position) < 2)
		{
			
			Debug.Log("eee");
			
			Destroy(docteur);
			
		}
	}

	private float distance(Vector3 v1, Vector3 v2)
	{
		return Mathf.Sqrt(Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.y - v2.y), 2) + Mathf.Pow((v1.z - v2.z), 2));
	}

}
