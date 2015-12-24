using UnityEngine;
using System.Collections;

public class René : MonoBehaviour {
	public GameObject joueur;
	public GameObject t;
	public GameObject t1;
	public GameObject t2;
	public GameObject door;
	public GameObject trou;
	private Animation A;
	private Animation A1;
	private Animation A2;
	private bool b;
	private bool c;
	private bool d;
	private bool e;
	private bool f;
	private bool g;
	// Use this for initialization
	void Start () {
		b = false;
		c = false;
		d = false;
		e = false;
		f = false;
		g = false;
		A = GetComponent<Animation> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (distance(joueur.transform.position, t.transform.position) < 12)
		{
			Debug.Log ("ok");
			b=true;
				
		}
		if (b == true) {
			transform.position = Vector3.MoveTowards (transform.position, t1.transform.position, 0.5F);
		}
		if (distance(transform.position, t1.transform.position) < 10)
		{
			Debug.Log ("ok2");
			b=false;
			c=true;
			d=true;
			
		}
		if (c == true) {

			if(d==true)
			{A.Play("Anima");
				d=false;
			}
			transform.position = Vector3.MoveTowards (transform.position, t2.transform.position, 0.5F);
		}
		if (distance(transform.position, t2.transform.position) < 12)
		{   e=true;
			c=false;
			Debug.Log ("ok3");
		
			if(e==true)
			{	A.Play("Ani");
				e=false;
			}

				f=true;
			

			
		}
		if (f == true) {
			Debug.Log ("1");
			if (distance(joueur.transform.position, transform.position) < 70)
			{	Debug.Log ("2");
				g=true;
			}
			if (g==true)
			{		transform.position = Vector3.MoveTowards (transform.position, door.transform.position, 0.5F);
			}
		}
		if (distance(transform.position, door.transform.position) < 12)
		{        
			trou.SetActive(true);
			
			
		}
		if (distance(transform.position, door.transform.position) < 12)
		{   	
			GameObject.Destroy(gameObject); 
			
			
		}
		
	}

	private float distance(Vector3 v1, Vector3 v2)
	{
		return Mathf.Sqrt(Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.y - v2.y), 2) + Mathf.Pow((v1.z - v2.z), 2));
	}
}
