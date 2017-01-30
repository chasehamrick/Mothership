using UnityEngine;
using System.Collections;

public class Player1Controls : MonoBehaviour {

	public GameObject ship;
    public GameObject BigBulletPrefab;
    public GameObject BigBulletSpawnPoint;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float bulletSpeed = 500;
    public Vector3 shipPos;
    public Vector3 playerDirection;
    Quaternion playerRotation;

	// Use this for initialization
	void Start () {
		
	}
	
    void Update ()
    {
        if (Time.time >= coolDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shipPos = ship.transform.position;
                playerDirection = ship.transform.forward;
                float spawnDistance = 1;

                Vector3 spawnPos = BigBulletSpawnPoint.transform.position;
                playerRotation = BigBulletSpawnPoint.transform.rotation;

                GameObject Clone;
                Clone = Instantiate(BigBulletPrefab, spawnPos, playerRotation) as GameObject;
                Clone.GetComponent<Rigidbody2D>().velocity = transform.up * 500;

                coolDown = Time.time + attackSpeed;
            }
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.A)) {
			ship.transform.Rotate (new Vector3 (0, 0, 4f));
		}
		if (Input.GetKey(KeyCode.D)) {
			ship.transform.Rotate (new Vector3 (0, 0, -4f));
		}
        
    }
}
