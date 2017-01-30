using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public int score;
    public const int maxHealth = 5;
    public int currentHealth = maxHealth;
    public Text scoreText;
    public Image health;
    
    

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        score = 0;
	}

    // Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score.ToString();
    }

    public void TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount;
        if (amount == 1)
        {
            float current = health.GetComponent<RectTransform>().rect.width;
            float newValue = current - 20;

            health.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newValue);
        }
        else if ( amount == 5)
        {
            health.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            health.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        }
        Debug.Log("Taken Damage!");
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }
}
