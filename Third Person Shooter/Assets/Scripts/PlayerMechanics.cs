﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour {

	#region Moving Variables

	public float moveSpeed;

	public float rotationSpeed;

	#endregion

	#region Bullet Variables

	public Transform prefab;

	public List<Transform> transforms;

	public string deathTag;

	public float launchSpeed;

	#endregion

	#region Private Variables

	private CharacterController controller;

	#endregion

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		MovePlayer();
		RotatePlayer();

		FireBullets();
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

		Vector3 moveVector = transform.forward * (vertical * moveSpeed);

		controller.SimpleMove(moveVector);
	}

	void FireBullets()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Transform instance = Instantiate(prefab, controller.transform.position + (controller.transform.forward * transform.localScale.y), Quaternion.identity);

			Rigidbody rb = instance.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.velocity = controller.transform.forward * launchSpeed;
			}

			transforms.Add(instance);

		}

		foreach (Transform t in transforms)
		{
			BulletDestroyer destroyer = t.GetComponent<BulletDestroyer>();

			if (destroyer != null)
			{
				destroyer.destroyTag = deathTag;
			}
	
		}

	}

}
