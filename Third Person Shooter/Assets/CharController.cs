using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private CharacterController character;

	public float moveSpeed = 5f;

	public float turnSpeed = 5f;

	public bool canMove = true;

	void Start ()
	{
		character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!canMove)
			return;

		float moveVertical = Input.GetAxis("Vertical");

		Vector3 moveVector = transform.forward * (moveVertical * moveSpeed);

		character.SimpleMove(moveVector);

		float moveHorizontal = Input.GetAxis("Horizontal");

		Vector3 turnVector = Vector3.up * (moveHorizontal * turnSpeed);

		character.transform.Rotate(turnVector);

	}
}
