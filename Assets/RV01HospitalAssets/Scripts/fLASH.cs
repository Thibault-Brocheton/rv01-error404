using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class fLASH : MonoBehaviour {

    public GameObject lit;
    // Use this for initialization


    void Start () {
      
        
       
    }
	
	// Update is called once per frame
	void Update () {
  
            if (distance(transform.position, lit.transform.position) < 20)
            {



            Auto.LoadLevel("Bar", 2, 1, Color.black);

        }
        
    }

    private float distance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.y - v2.y), 2) + Mathf.Pow((v1.z - v2.z), 2));
    }
}
