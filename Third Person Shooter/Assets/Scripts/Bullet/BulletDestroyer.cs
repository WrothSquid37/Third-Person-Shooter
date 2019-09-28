using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

	public List<string> destroyTags;

	private void OnCollisionEnter(Collision other)
	{	
		foreach (string s in destroyTags)
		{
			if (other.gameObject.CompareTag(s))
			{
				Destroy(gameObject);
			}
		}
	}

}
