using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField, Tooltip("Time before it disapears from screen")]
    protected float _timeBeforeDisable;
    public virtual void ShootBullet()
    {
        Debug.Log("Shoot fired");
    }


    /// <summary>
    /// Disable the bullet object after some time
    /// </summary>
    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(_timeBeforeDisable);
        gameObject.SetActive(false);
    }
}
