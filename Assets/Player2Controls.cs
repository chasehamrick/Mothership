using UnityEngine;
using System.Collections;

public class Player2Controls : MonoBehaviour {

	public GameObject ship;
	private Rigidbody2D body;
	public GameObject cam;
    public GameObject SmallBulletPrefab;
    public GameObject SmallBulletSpawnPoint;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float bulletSpeed = 500;
    public Vector3 shipPos;
    public Vector3 playerDirection;
    Quaternion playerRotation;

    // Use this for initialization
    void Start () {
		body = ship.transform.Find ("Ship").GetComponent<Rigidbody2D> ();
		ship = ship.transform.Find ("Ship").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			body.AddRelativeForce (new Vector2 (0f, 70f));
		}
        if (Time.time >= coolDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //body.AddRelativeForce (new Vector2 (0f, -70f));
                shipPos = ship.transform.position;
                playerDirection = ship.transform.forward;
                float spawnDistance = 1;

                Vector3 spawnPos = SmallBulletSpawnPoint.transform.position;
                playerRotation = SmallBulletSpawnPoint.transform.rotation;

                GameObject Clone;
                Clone = Instantiate(SmallBulletPrefab, spawnPos, playerRotation) as GameObject;
                Clone.GetComponent<Rigidbody2D>().velocity = transform.up * 500;

                coolDown = Time.time + attackSpeed;
            }
        }
		float camDis = cam.transform.position.y - ship.transform.position.y;
		Vector3 mouse = cam.GetComponent<Camera> ().ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));
		float AngleRad = Mathf.Atan2 (mouse.y - ship.transform.position.y, mouse.x - ship.transform.position.x);
		float angle = ((180 / Mathf.PI) * AngleRad) - 90;
		body.rotation = angle;
		Vector2 acceleration = body.velocity / 10.0f;
		transform.position = (ship.transform.position - Vector3.forward * 10) + (Vector3) acceleration;
	}
}
