using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMechanics : MonoBehaviour {

	
	public float moveSpeed;
	public float rotationSpeed;

    float orginalDamageValue;

    [HideInInspector] public int fireMode = 0;

	public Transform prefab;
	public float launchSpeed = 25f;
    public float damage = 10f;

    public float fireRate = 10f;
    private float nextTimeToFire = 0;

    CharacterController controller;
    public GameOverMenu menu;

    public float minHp = 0f;
    public float maxHp = 100f;

    [HideInInspector] public float hp = 100f;
    [HideInInspector] public float shieldHp = 100f;
    [HideInInspector] public bool shieldActivated = false;

    bool runOnce = false;

	void Start()
	{
		controller = GetComponent<CharacterController>();
        orginalDamageValue = damage;
        fireMode = 0;
    }

	void Update()
	{
		MovePlayer();
		RotatePlayer();

        KeyFunctions();

		if (!shieldActivated) FireBullets(fireMode);
        if (hp <= 0 && !runOnce)
        {
            menu.ShowMenu();
            gameObject.SetActive(false);
        }

        HealthFunctions();

    }

    #region Movement

    private void RotatePlayer()
	{
		float horizontal = Input.GetAxis("Horizontal");

		Vector3 rotationVector = Vector3.up * (horizontal * rotationSpeed);

		controller.transform.Rotate(rotationVector);
	}

	private void MovePlayer()
	{

		float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(0, 0, 0);

        if (!shieldActivated) moveVector = transform.forward * (vertical * moveSpeed);
        if (shieldActivated) moveVector = transform.forward * (vertical * (moveSpeed + 3));

        controller.SimpleMove(moveVector);
	}

    #endregion

    #region Player Bullets

    private void KeyFunctions()
    {
        if (Input.GetKeyDown(KeyCode.B) && !(shieldHp < 0))
        {
            shieldActivated = !shieldActivated;
        }
    }

	void FireBullets(int mode)
	{
		if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)
		{
			Transform instance = Instantiate(prefab, controller.transform.position + (controller.transform.forward * transform.localScale.y), Quaternion.identity);

			Rigidbody rb = instance.GetComponent<Rigidbody>();

            BulletDestroyer bulletScript = instance.GetComponent<BulletDestroyer>();

            bulletScript.SetSender("Player");
            bulletScript.SetDamage(damage);

            if (bulletScript != null) bulletScript.SetDamage(damage);

			if (rb != null && mode == 0)
			{
				rb.velocity = controller.transform.forward * launchSpeed;
                nextTimeToFire = Time.time + (1f / fireRate);
            }
            if (rb != null && mode == 1)
            {
                rb.velocity = controller.transform.forward * launchSpeed;
                nextTimeToFire = Time.time + (1f / (fireRate + 7f));
            }

        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            BulletDestroyer b = other.gameObject.GetComponent<BulletDestroyer>();
            string sender = b.GetSender();
            if (b != null && sender != "Player") TakeDamage(b.damage);
        }
    }

    #endregion

    #region Health...

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

    #endregion

    #region Powerup Functions 

    public void SetDamage(float amount, bool orginal)
    {
        if (!orginal) damage = amount;
        if (orginal) damage = orginalDamageValue;
    }
    
    #endregion

}
