using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour {

    public const int maxHealth = 5;
    public int currentHealth = maxHealth;

    public void Start()
    {

    }

    public void Update()
    {

    }

	public void TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount;
        Debug.Log("Taken Damage!");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }
}
