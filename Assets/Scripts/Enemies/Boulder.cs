using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour, IDamagable
{
    public enum BoulderSize { Small, Medium }
    
    [SerializeField]
    private BoulderSize _boulderSize;

    [SerializeField]
    private ObjectPool _objectPool;

    [Space(10), Header("Boulder rotation around its axis setting")]
    [SerializeField, Tooltip("Referance to the boulder GFX")]
    private Transform _boulderGFX;
    [SerializeField, Tooltip("Rotation around its axis speed")]
    private float _axisRotationSpeed;

    private void FixedUpdate()
    {
        RotateAroundAxis();
    }

    /// <summary>
    /// Rotate the bullet GFX around its z axis
    /// </summary>
    private void RotateAroundAxis()
    {
        _boulderGFX.transform.RotateAround(transform.position, Vector3.forward, _axisRotationSpeed * Time.deltaTime);
    }


    //---------------------------------------------------------------------------------------------
    public void TakeDamage()
    {
        Debug.Log("Boulder hit");

        GameObject _smallExplosion = _objectPool.GetFromPool(_objectPool.SmallExplosionPool);

        if (_smallExplosion != null)
        {
            _smallExplosion.transform.position = transform.position;
            _smallExplosion.transform.rotation = transform.rotation;
            _smallExplosion.SetActive(true);
            _smallExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }


}
