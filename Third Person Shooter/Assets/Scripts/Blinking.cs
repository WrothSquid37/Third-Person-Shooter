using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour {

	public float blinkInterval;

	public Vector2 ranges;

	private Light playerLight;

	void Start()
	{
		playerLight = GetComponent<Light>();

		StartCoroutine(BlinkLight(blinkInterval));

	}

	IEnumerator BlinkLight(float speed)
	{

		float x = 0;

		while (true)
		{

		

			yield return new WaitForSeconds(speed);

		}
	}

}
