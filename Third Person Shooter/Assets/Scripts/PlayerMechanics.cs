using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour { 

	public float moveSpeed;

	public float rotationSpeed;

	private CharacterController controller;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		MovePlayer();
		RotatePlayer();
	}

	private void RotatePlayer()
	{
		float horizontal = Input.GetAxis("Horizontal");

		Vector3 rotationVector = Vector3.up * (horizontal * rotationSpeed);

		controller.transform.Rotate(rotationVector);
	}

	private void MovePlayer()
	{
		float vertical = Input.GetAxis("Vertical");

		Vector3 moveVector = Vector3.forward * (vertical * moveSpeed);

		controller.SimpleMove(moveVector);
	}


}
