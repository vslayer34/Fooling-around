using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandle : MonoBehaviour
{
    [SerializeField, Tooltip("Referance for the object pool")]
    private ObjectPool _objectPool;
    [SerializeField, Tooltip("Referance to input link")]
    private SO_InputLink _InputLink;

    private GameObject _projectile;

    #region Enable, Disable
    private void OnEnable()
    {
        _InputLink.OnShoot += SpawnProjectile;
    }

    private void OnDisable()
    {
        _InputLink.OnShoot -= SpawnProjectile;
    }
    #endregion

    public void SpawnProjectile()
    {
        _projectile = _objectPool.GetFromPool(_objectPool.BulletPool);

        if (_projectile != null)
        {
            _projectile.transform.position = transform.position;
            _projectile.transform.rotation = transform.rotation;
            _projectile.SetActive(true);
            _projectile.GetComponent<Projectile>().ShootBullet();
        }        
    }
}
