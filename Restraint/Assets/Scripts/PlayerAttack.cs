using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon activeWeapon;
    public Transform AttachPoint;

    bool canPickUpWeapon;
    Weapon collidingWeapon;

    void Start()
    {
    }

    private void PickUpWeapon()
    {
        if (collidingWeapon)
        {
            if (activeWeapon)
                Destroy(activeWeapon.gameObject);

            activeWeapon = Instantiate(collidingWeapon, transform);
            activeWeapon.transform.position = AttachPoint.position;

            Destroy(collidingWeapon.gameObject);
            collidingWeapon = null;
        }
    }

    void Update()
    {
        //if activeWeapon is not null (has teh weapon prefab been cloned)
        if (activeWeapon)
        {
            if (activeWeapon.IsAutomatic)
            {
                if (Input.GetButton("Fire1"))//left mouse button and right controller trigger
                {
                    if (activeWeapon.HasAmmo())
                        activeWeapon.Fire(activeWeapon.Spawn.position);
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))//left mouse button and right controller trigger
                {
                    if (activeWeapon.HasAmmo())
                        activeWeapon.Fire(activeWeapon.Spawn.position);
                }
            }
        }

        if (canPickUpWeapon)
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpWeapon();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            collidingWeapon = collision.GetComponent<Weapon>();
            canPickUpWeapon = true;

        }
    }
}
