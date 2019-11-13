using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

    float bounces = 0f;
    public float maxBounces = 4f;
    public float damage;
    public string sender;
	float velocityMult = 1f;
	Rigidbody rb;

    public List<string> destroyTags;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Physics.IgnoreLayerCollision(11,11);

        rb.velocity *= 1.001f;

        
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    public void SetSender(string value)
    {
        sender = value;
    }

    public string GetSender()
    {
        return sender;
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
