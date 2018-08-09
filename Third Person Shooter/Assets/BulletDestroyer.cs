using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

	[HideInInspector]
	public string destroyTag;

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag(destroyTag))
		{
			Destroy(gameObject);
		}
	}

}
