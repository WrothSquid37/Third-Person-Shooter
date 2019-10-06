using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

    float bounces = 0f;
    public float maxBounces = 4f;
    public float damage;

    public List<string> destroyTags;

    void Update()
    {
        Physics.IgnoreLayerCollision(11,11);
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    private void OnCollisionEnter(Collision other)
	{
        bounces += 1f;
        foreach(string s in destroyTags)
        {
            if (other.gameObject.CompareTag(s))
            {
                Destroy(gameObject);
            }
        }
		if (bounces > maxBounces)
		{
			Destroy(gameObject);
		}	
	}

}
