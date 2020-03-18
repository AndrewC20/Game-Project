using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs: EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }


    public Transform aimTransform;
    public Transform aimGunEndPointTransform;

    private Animator aimAnimator;

    private void Awake()
    {
        aimAnimator = aimTransform.GetComponent<Animator>();
    }
    void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    public static Vector3 GetMousePos()
    {
        Vector3 vec = GetMousePositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = GetMousePositionWithZ();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMousePos();
            aimAnimator.SetTrigger("Shoot");
            OnShoot?.Invoke(this, new OnShootEventArgs {
                            gunEndPointPosition = aimGunEndPointTransform.position, shootPosition = mousePosition,
            });
        }
    }

    public static Vector3 GetMousePositionWithZ()
    {
        return GetMousePositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMousePositionWithZ(Camera worldCamera)
    {
        return GetMousePositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMousePositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
