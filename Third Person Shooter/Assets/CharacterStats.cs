using UnityEngine;

public class CharacterStats : MonoBehaviour {

	#region Variables

	private float health = 0f;

	public float Hp
	{
		get
		{
			return health;
		}
	}

	public float maxHealth = 100f;

	public bool isAlive = true;

	#endregion

	#region Custom Methods

	void Start()
	{
		health = maxHealth;
	}

	public void Damage(float amount)
	{
		if (health <= 0)
			isAlive = false;

		if (amount <= 0)
			return;

		health -= amount;
	}

	public void Heal(float amount)
	{
		if (health <= 0)
			isAlive = false;
		
		if (amount <= 0)
			return;

		health -= amount;
	}

	public void SetHealth(float amount) {

		if (amount <= 0 || amount > maxHealth)
			return;

		health = amount;

	}

	#endregion

}
