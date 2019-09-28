using UnityEngine;

public class PlayerMechanics : MonoBehaviour {

	
	public float moveSpeed;
	public float rotationSpeed;

	public Transform prefab;
	public float launchSpeed;

    public float fireRate = 10f;
    private float nextTimeToFire = 0;

    CharacterController controller;

    [HideInInspector] public float hp = 100f;
    [HideInInspector] public float shieldHp = 50f;

    bool shieldActivated = false;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		MovePlayer();
		RotatePlayer();

        KeyFunctions();

		if (!shieldActivated) FireBullets();
        if (hp <= 0) transform.gameObject.SetActive(false);
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

    private void KeyFunctions()
    {
        if (Input.GetKeyDown(KeyCode.B) && !(shieldHp < 0))
        {
            shieldActivated = !shieldActivated;
        }
    }

	void FireBullets()
	{
		if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)
		{
			Transform instance = Instantiate(prefab, controller.transform.position + (controller.transform.forward * transform.localScale.y), Quaternion.identity);

			Rigidbody rb = instance.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.velocity = controller.transform.forward * launchSpeed;
                nextTimeToFire = Time.time + (1f / fireRate);
            }

		}

	}

    public void TakeDamage(float amount)
    {
        if (shieldHp >= 0 && shieldActivated)
        {
            shieldHp -= amount;
        }
        else
        {
            hp -= amount;
        }       
        if (hp < 0) hp = 0;
        if (shieldHp < 0) shieldActivated = false;
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
            TakeDamage(5);
        }
    }

}
