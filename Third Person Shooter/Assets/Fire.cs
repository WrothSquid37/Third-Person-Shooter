﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public Transform prefab;

	public float lifetime = 7f;

	public float fireRate = 1;

	private float nextTimeToFire = 0;

	public float shootVelocity = 5f;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + fireRate;

			Shoot();
		}
	}

	void Shoot()
	{
		Vector3 position = transform.position;

		Transform instance = Instantiate(prefab, (Vector3)transform.position + (transform.forward * 3f), Quaternion.identity);

		Rigidbody rb = instance.GetComponent<Rigidbody>();

		rb.velocity = transform.forward * shootVelocity;

		Destroy(instance.gameObject, lifetime);	

	}

}
