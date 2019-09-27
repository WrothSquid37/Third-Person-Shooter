using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public Transform prefab;

    public float launchMultiplier = 10f;

    public float fireRate = 10f;

    public LayerMask allowedLayers;

    public float range = 100f;

    public float damage = 5f;

    public float startHealthpoints = 100f;

    public float maxHealthpoints = 100f;

    private float hp = 100f;

    private float nextTimeToFire = 0;

    public Animation animation;

    private void Start()
    {
        hp = startHealthpoints;
    }

    private void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, allowedLayers))
        {

            Vector3 shotOffset = transform.forward * (prefab.localScale.x * 2.1f);

            print(true);

            if (Time.time >= nextTimeToFire) {

                Transform clone = Instantiate(prefab, transform.position + shotOffset, Quaternion.identity);

                Rigidbody rb = clone.GetComponent<Rigidbody>();

                rb.velocity = transform.forward * launchMultiplier;

                nextTimeToFire = Time.time + (1f / fireRate);

            }

        }

    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp < 0) Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            TakeDamage(25);
        }
    }

}
