using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private float bulletDamage;
    public float bulletSpeed;
    public float bulletLife;

    // Start is called before the first frame update
    void Start()
    {
        //call the destroyBullet function after bulletLife seconds
        Invoke("destroyBullet", bulletLife);
    }

    // Update is called once per frame
    void Update()
    {
        //You can still use tranlate to move the bullet as long as either the bullet
        //or the enemy contains a rigidbody.
        //You cannot detect collisions unless one of the game objects has a rigidbody
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

    }

    void destroyBullet()
    {
        //Remove the bullet from the screen
        Destroy(this.gameObject);
    }

    public float getBulletDamage()
    {
        return bulletDamage;
    }

    public void setBulletDamage(float d)
    {
        bulletDamage = d; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Weapon"))
        {
            destroyBullet();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Weapon"))
        {
            destroyBullet();
        }

    }
}
