using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    public Text scoreText;

    // Use this for initialization
    void Start () {
        GameObject score = GameObject.Find("Player1");
        ScoreScript scoreScript = score.GetComponent<ScoreScript>();

        scoreText.text = "You destroyed " + scoreScript.score.ToString() + " meteors before the mothership was destroyed";

        Destroy(score);
        SceneManager.UnloadScene("MainScene");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
            SceneManager.UnloadScene("end screen");
        }
    }
}
