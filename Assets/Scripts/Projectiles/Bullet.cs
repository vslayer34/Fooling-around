using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : Projectile
{
    [Header("Bullet properites")]
    
    [SerializeField]
    private float _bulletSpeed;
    




    [Header("Bullet rotation speed"), Space(5)]
    [SerializeField]
    private float _axisRotationSpeed;


    // referance to the bullet sprite to rotate it
    private Transform _bulletGFX;
    private Rigidbody2D _rb;
    
    //----------------------------------------------------------------------------------------------------------


    private void Awake()
    {
        _bulletGFX = GetComponentInChildren<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        // FireBullet();
    }

    private void Start()
    {
        StartCoroutine("DisableAfterTime");
    }

    private void FixedUpdate()
    {
        RotateAroundAxis();
    }

    //---------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Rotate the bullet GFX around its z axis
    /// </summary>
    private void RotateAroundAxis()
    {
        _bulletGFX.transform.RotateAround(transform.position, Vector3.forward, _axisRotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Fire the bullet at its speed
    /// </summary>
    private void FireBullet()
    {
        _rb.AddForce(_rb.transform.up * _bulletSpeed, ForceMode2D.Impulse);
    }


    public override void ShootBullet()
    {
        base.ShootBullet();
        FireBullet();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            // collision.collider.GetComponent<IDamagable>()?.TakeDamage();
            if (collision.collider.GetComponent<IDamagable>() is IDamagable hitObject)
            {
                hitObject.TakeDamage();
                gameObject.SetActive(false);
            }
        }
    }
}
