using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SmallMeteorScript : MonoBehaviour {

    //public GameObject Meteor;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    ScoreScript scoreScript;


    // Use this for initialization
    void Start () {
        GameObject score = GameObject.Find("Player1");
        scoreScript = score.GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    float speed = 25;
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "BulletSmall(Clone)")
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[spawnPointIndex].position;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(col.gameObject);
            scoreScript.score += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ship")
        {
            scoreScript.TakeDamage(1);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[spawnPointIndex].position;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            scoreScript.score += 1;

            if (scoreScript.currentHealth == 0)
            {
                SceneManager.LoadScene("end screen");
                SceneManager.UnloadScene("MainScene");
            }
        }

        else
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);
            if (col.gameObject.name != "Meteor")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
