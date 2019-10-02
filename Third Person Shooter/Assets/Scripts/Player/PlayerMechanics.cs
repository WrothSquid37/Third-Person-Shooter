using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMechanics : MonoBehaviour {

	
	public float moveSpeed;
	public float rotationSpeed;

	public Transform prefab;
	public float launchSpeed;

    public float fireRate = 10f;
    private float nextTimeToFire = 0;

    CharacterController controller;

    public float minHp = 0f;
    public float maxHp = 100f;

    [HideInInspector] public float hp = 100f;
    [HideInInspector] public float shieldHp = 100f;

    [HideInInspector] public bool shieldActivated = false;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
        // Methods for moving and rotating player
		MovePlayer();
		RotatePlayer();

        // Method used key bindings used to turn on shield
        KeyFunctions();

        // if shield activated you are not allowed to fire bullets
		if (!shieldActivated) FireBullets();
        // temporary way tellin you died
        if (hp <= 0) SceneManager.LoadScene(0);

        HealthFunctions();


    }

	private void RotatePlayer()
	{
        // get the horizontal axis (A and D).
		float horizontal = Input.GetAxis("Horizontal");

        // create a vector for rotation from horizontal variable
		Vector3 rotationVector = Vector3.up * (horizontal * rotationSpeed);

        // rotate the player
		controller.transform.Rotate(rotationVector);
	}

	private void MovePlayer()
	{
        // get the vertical axis (W and S).
		float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(0, 0, 0);

        // move vector for back and forth movement
        if (!shieldActivated) moveVector = transform.forward * (vertical * moveSpeed);

        if (shieldActivated) moveVector = transform.forward * (vertical * (moveSpeed + 3));

        // move the player with a built-in method
        controller.SimpleMove(moveVector);
	}

    private void KeyFunctions()
    {
        if (Input.GetKeyDown(KeyCode.B) && !(shieldHp < 0))
        {
            // flip the shield state
            shieldActivated = !shieldActivated;
        }
    }

	void FireBullets()
	{
        // fire bullets if space is held down and time is bigger that next time to fire
		if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)
		{
            // create the instance
			Transform instance = Instantiate(prefab, controller.transform.position + (controller.transform.forward * transform.localScale.y), Quaternion.identity);

            // get the rigidbody and set the velocity to the forward direction of the player down below
			Rigidbody rb = instance.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.velocity = controller.transform.forward * launchSpeed;
                if (!shieldActivated) nextTimeToFire = Time.time + (1f / fireRate);
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
        if (hp > 100f) hp = 100f;
    }

    public void AddShield(float amount)
    {
        shieldHp += amount;
        if (hp > 100f) hp = 100f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            TakeDamage(5);
        }
    }

    private void HealthFunctions()
    {
        if (hp <= 0)
        {
            hp = 0;
        }
        if (hp >= 100)
        {
            hp = 100;
        }
    }

}
