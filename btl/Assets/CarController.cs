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
	private float dirZ;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		dirZ = Input.GetAxisRaw("Vertical");
		dirX = Input.acceleration.x;
		dirZ = Input.acceleration.z;
	}

	private void FixedUpdate()
	{
//		float moveZ = dirZ * runSpeed * Time.fixedDeltaTime;
		float moveZ = dirZ * runSpeed * Time.fixedDeltaTime;
		transform.Translate(new Vector3(0,0,-moveZ));
		float rotateY = dirX * rotateSpeed * Time.fixedDeltaTime;
		transform.Rotate(0,rotateY,0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Item"))
		{
			Destroy(other.gameObject);
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
