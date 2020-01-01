using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

	[SerializeField] private float runSpeed;

	[SerializeField] private float rotateSpeed;
	[SerializeField] private float timeToReturn;
	[SerializeField] private float speedUp;

	[SerializeField] private GameObject endPanel;
	
	private float dirX;
	private float dirZ;
	
	// Use this for initialization
	void Start () {
		endPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirX = Input.acceleration.x;
		dirZ = Input.acceleration.z;
	}

	private void FixedUpdate()
	{
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

		if (other.CompareTag("FinishLine"))
		{
			Time.timeScale = 0;
			endPanel.SetActive(false);
		}
	}

	IEnumerator ReturnSpeed()
	{
		yield return new WaitForSeconds(timeToReturn);
		runSpeed = 15;
	}

	public void HomeButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}

	public void RestartButton()
	{
		SceneManager.LoadScene("race_track_lake");
		Time.timeScale = 1;
	}
	
}
