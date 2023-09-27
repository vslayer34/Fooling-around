using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [field: Header("This part is responsible for the bullets prefabs")]
    [field: SerializeField, Tooltip("Pool for the bullets")]
    public List<GameObject> BulletPool { get; private set; } = new();

    [SerializeField, Tooltip("Bullet prefab")]
    private GameObject _bullet;

    [SerializeField]
    private int _poolSize;


    [field: Space(10), Header("This part is responsible for small explosions prefabs")]
    [field: SerializeField, Tooltip("Pool for small explosions")]
    public List<GameObject> SmallExplosionPool { get; private set; } = new();

    [SerializeField, Tooltip("Small explosion prefab")]
    private GameObject _smallExplosion;

    [SerializeField]
    private int _smallExplosionPoolSize;

    private void Start()
    {
        CreatePool(BulletPool, _bullet, _poolSize);
        CreatePool(SmallExplosionPool, _smallExplosion, _smallExplosionPoolSize);
    }

    private void CreatePool(List<GameObject> list, GameObject prefab, int poolSize)
    {
        // list = new();
        GameObject temp;

        for (int i = 0; i < poolSize; i++)
        {
            temp = Instantiate(prefab);
            temp.SetActive(false);
            list.Add(temp);
        }
    }


    public GameObject GetFromPool(List<GameObject> list)
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                return list[i];
            }
        }

        return null;
    }
}
