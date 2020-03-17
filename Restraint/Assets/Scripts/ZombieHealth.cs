using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : HealthComponent
{
    private GameManager manager;
    public GameObject splatter;
    // Added a tag bullet to fix issue of zombie not registering damage
    // May need to remove later or add something for the car
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ApplyDamage(10);        
        }
        if (Health <= 0)
        {
            manager.zombieCount--;
            Instantiate(splatter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
}
