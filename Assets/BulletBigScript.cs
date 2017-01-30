using UnityEngine;
using System.Collections;

public class BulletBigScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidBody = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = transform.up * 500;
        if(gameObject.name == "BulletBig")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.name == "Ship")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);
            Destroy(gameObject);
        }
    }

}
