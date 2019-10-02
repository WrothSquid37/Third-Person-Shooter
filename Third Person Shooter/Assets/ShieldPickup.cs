using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour {

    public float shieldAmount = 20f;

    public float amp;
    public float period;
    float ty = 0;
    float vy = 0;

    private void Start()
    {
        vy = transform.position.y;
    }

    private void Update()
    {
        ty = Mathf.Sin(Time.time / period) * amp;
        Vector3 v = new Vector3(transform.position.x, vy + ty, transform.position.z);
        transform.position = v;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMechanics player = other.GetComponent<PlayerMechanics>();

            player.AddShield(shieldAmount);

            Destroy(gameObject);
        }
    }

}
