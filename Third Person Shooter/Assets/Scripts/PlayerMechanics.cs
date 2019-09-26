using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour {

	
	public float moveSpeed;
	public float rotationSpeed;

	public Transform prefab;
	public float launchSpeed;

	CharacterController controller;

    [HideInInspector] public float hp = 100f;

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

		}

	}

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp < 0) hp = 0;
    }

    public void Heal(float amount)
    {
        hp += amount;
        if (hp > 0) hp = 100f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }

}
