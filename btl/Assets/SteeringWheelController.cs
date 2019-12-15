using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{

	private float rotateY;

	[SerializeField] private float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		rotateY = Input.GetAxisRaw("Horizontal");
		if (rotateY==0)
		{
			transform.Rotate(0,0,0);
		}
	}

	private void FixedUpdate()
	{
		float dirY = rotateY * speed * Time.fixedDeltaTime;
		transform.Rotate(0,dirY,0);
	}
}
