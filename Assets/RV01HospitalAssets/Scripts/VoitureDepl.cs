using UnityEngine;
using System.Collections;

public class VoitureDepl : MonoBehaviour {

    private NavMeshAgent navAgent;  // L'objet qui va naviguer
    private Vector3 target; // La cible vers laquelle l'objet se déplace
    public GameObject arbre;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        target = arbre.transform.position;

    }

    void Update()
    {

        navAgent.SetDestination(target);

        if (distance(transform.position, arbre.transform.position) < 10)
        {



            Auto.LoadLevel("Hostpital3", 2, 1, Color.black);

        }


    }

    private float distance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.y - v2.y), 2) + Mathf.Pow((v1.z - v2.z), 2));
    }
}
