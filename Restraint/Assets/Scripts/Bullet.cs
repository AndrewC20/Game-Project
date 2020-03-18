using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 2;

    private void Start()
    {
        Invoke("DestroyBullet", 5);
    }

    //sets the velocity of the bullet
    public void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * Speed;
    }

    //can be extended by later (virtual)
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Bullet")) { }
        else
        {
            DestroyBullet();
        }
    }

    //can be extended by later (virtual)
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Bullet")) { }
        else
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
