using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

	[SerializeField] private float runSpeed;

	[SerializeField] private float rotateSpeed;
	[SerializeField] private float timeToReturn;
	[SerializeField] private float speedUp;
	private float dirX;

	private float moveZ,rotateY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveZ = Input.GetAxisRaw("Vertical");
		rotateY = Input.GetAxisRaw("Horizontal");

		dirX = Input.acceleration.x * runSpeed;
	}

	private void FixedUpdate()
	{
		float dirZ = moveZ * runSpeed * Time.fixedDeltaTime;
		transform.Translate(new Vector3(dirX,0,dirZ));
		float dirY = rotateY * rotateSpeed * Time.deltaTime;
		transform.Rotate(0,dirY,0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Item"))
		{
			runSpeed = speedUp;
			StartCoroutine(ReturnSpeed());
		}
	}

	IEnumerator ReturnSpeed()
	{
		yield return new WaitForSeconds(timeToReturn);
		runSpeed = 15;
	}
}
