using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public float healAmount = 25f;
    public float amp;
    public float period;
    public float rotationSpeed = 0.5f;
    float ty = 0;
    float vy = 0;

    private void Start()
    {
        vy = transform.position.y;
    }

    private void Update()
    {
        ty = Mathf.Sin(Time.time/period) * amp;
        Vector3 v = new Vector3(transform.position.x, vy + ty, transform.position.z);
        transform.position = v;
        //transform.Rotate(Vector3.up * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMechanics player = other.GetComponent<PlayerMechanics>();

            if (player != null)
            {
                player.Heal(healAmount);
            }

            Destroy(gameObject);

        }
    }

}
