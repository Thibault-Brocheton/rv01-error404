using UnityEngine;
using System.Collections;

public class VitesseDroite : MonoBehaviour {
	private Rigidbody rb;
	public float velocity;
	private Vector3 pred;
	private float res;
	
	private float MaxX = 0.1941727F;
	private float MinX = -0.07830696F;
	private float MilieuX = 0F;
	
	private float MaxY = 0.4609751F;
	private float MinY = 0.1880738F;
	private float MilieuY = 0F;
	
	private float maxCalcX = -100F;
	private float minCalcX = 100F;
	
	private float maxCalcY = -100F;
	private float minCalcY = 100F;
	
	private int delta = 50;
	
	public int movement = 0;
	
	// Use this for initialization
	void Start () {
		velocity = 0;
		pred = new Vector3(0,0,0);
		MilieuX = (MaxX+MinX)/2;
		MilieuY = (MaxY+MinY)/2;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		delta--;
		if(delta==0)
		{
			delta=10;
			
			Vector3 temp = transform.position;

			
			int tempMovement=0;
			
			if(pred.y>=MilieuY && temp.y>=MilieuY)
			{
				if(pred.x-temp.x<-0.001)
				{
					tempMovement = 1;
				}
				else if(pred.x-temp.x>0.001)
				{
					tempMovement = -1;
				}
			}
			else if(pred.y<MilieuY && temp.y<MilieuY)
			{
				if(pred.x-temp.x>0.001)
				{
					tempMovement = 1;
				}
				else if(pred.x-temp.x<-0.001)
				{
					tempMovement = -1;
				}
			}
			else if((pred.y<MilieuY && temp.y>MilieuY) || (pred.y>MilieuY && temp.y<MilieuY))
			{
				tempMovement = movement;
			}
			
			movement = tempMovement;

			if(movement==1)
				Debug.Log ("Droite Avance");
			else if(movement==-1)
				Debug.Log ("Droite recule");
			else
				Debug.Log ("Droite bouge pas");

			velocity = (float)Mathf.Round(((temp-pred).magnitude)/Time.deltaTime);
			
			pred = temp;
		}
	}
	
	
	
	
}
