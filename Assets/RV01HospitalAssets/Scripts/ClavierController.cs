﻿using UnityEngine;
using System.Collections;

public class ClavierController : MonoBehaviour {

	private Vector2 axeY = new Vector3(0,1,0);
	private float vitesse = 0.08F;
	private float rotateVitesse = 0.2F;
	
	private float startY;
	
	// Use this for initialization
	void Start () {
		startY = transform.position.y;
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		transform.eulerAngles = new Vector3(0,transform.rotation.eulerAngles.y,180);
		//transform.position = new Vector3(transform.position.x,startY,transform.position.z);
		
		

		/*float vitesseRoueLeft = RoueLeft.GetComponent<VitesseGauche>().velocity;
		float vitesseRoueRight = RoueRight.GetComponent<VitesseDroite>().velocity;
		
		int movementRoueLeft = RoueLeft.GetComponent<VitesseGauche>().movement;
		int movementRoueRight = RoueRight.GetComponent<VitesseDroite>().movement;
		
		float movementLeft = movementRoueLeft*vitesseRoueLeft;
		float movementRight = movementRoueRight*vitesseRoueRight;*/

		float movementLeft = 0F;
		float movementRight = 0F;

		if(Input.GetKey(KeyCode.Q))
		{
			movementLeft = -5F;
			movementRight = 5F;
		}
		else if(Input.GetKey(KeyCode.D))
		{
			movementLeft = 5F;
			movementRight = -5F;
		}
		else if(Input.GetKey(KeyCode.Z))
		{
			movementLeft = -20F;
			movementRight = -20F;
		}
		else if(Input.GetKey(KeyCode.S))
		{
			movementLeft = 20F;
			movementRight = 20F;
		}
		
		//Debug.Log("vLeft: "+vitesseRoueLeft+" and vRight:"+vitesseRoueRight);
		
		Rigidbody rb = GetComponent<Rigidbody>();
		if(movementLeft>0 && movementRight>0)
		{
			Vector3 vec = new Vector3(-(movementLeft+movementRight)*vitesse,0,0);
			vec = Quaternion.AngleAxis(transform.rotation.eulerAngles.y,Vector3.up) * vec;

			/*if(movementLeft>movementRight*2 && movementLeft>2 && movementRight>2)
			{
				transform.RotateAround(transform.position,axeY,Mathf.Abs(movementLeft-movementRight)*rotateVitesse);
			}
			else if(movementRight>movementLeft*2 && movementLeft>2 && movementRight>2)
			{
				transform.RotateAround(transform.position,axeY,-Mathf.Abs(-movementLeft+movementRight)*rotateVitesse);
			}*/
			rb.MovePosition(transform.position+vec);
		}
		else if(movementLeft<0 && movementRight<0)
		{
			Vector3 vec = new Vector3(-(movementLeft+movementRight)*vitesse,0,0);
			vec = Quaternion.AngleAxis(transform.rotation.eulerAngles.y,Vector3.up) * vec;
			rb.MovePosition(transform.position+vec);
		}
		else if((movementLeft>0 && movementRight<=0) || (movementLeft==0 && movementRight<0))
		{
			transform.RotateAround(transform.position,axeY,Mathf.Abs(movementLeft-movementRight)*rotateVitesse);
		}
		else if((movementRight>0 && movementLeft<=0) || (movementRight==0 && movementLeft<0))
		{
			transform.RotateAround(transform.position,axeY,-Mathf.Abs(-movementLeft+movementRight)*rotateVitesse);
		}
		
	}
}
