using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("track player stats")]
    private SO_GameTracker _gameTracker;

    [SerializeField, Tooltip("List of the spawn point in the map")]
    private List<Transform> _spawnPoints;

    // camera positions
    [SerializeField, Tooltip("Referance to the camera position in the world")]
    private Vector3 _cameraPosition;
    [SerializeField, Tooltip("How far are the span points from the border of the camera")]
    private float _offsetFromCameraBorder;
    private float _sizeFromCameraCenter;
   

    /// <summary>
    /// get the spawn point location in the x axis
    /// </summary>
    public float SpawnPositionX { get => _cameraPosition.x + _sizeFromCameraCenter + _offsetFromCameraBorder; }
    /// <summary>
    /// get the spawn point location from the y vector
    /// </summary>
    public float SpawnPositionY { get => _cameraPosition.y + _sizeFromCameraCenter + _offsetFromCameraBorder; }


    private void Start()
    {
        // gets camera size at the start of the game to calculate spawning offsets
        _sizeFromCameraCenter = Camera.main.orthographicSize / 2;
        // PositionSpawnPoints();
    }

    private void Update()
    { 
        PositionSpawnPoints();
        // StartCoroutine(PositionSpawnPoints());  
    }

    /// <summary>
    /// during the game it loops through the spawn ponts list
    /// and adjust their position to thee player
    /// </summary>
    private void PositionSpawnPoints()
    {
        
        // float offsetX = -3;
        // float offsetY = -3;
       
        _cameraPosition = Camera.main.transform.position;
        

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _spawnPoints[i].position = i switch
            {
                1 => new Vector2(_spawnPoints[i].position.x, SpawnPositionY),
                2 => new Vector2(SpawnPositionX, SpawnPositionY),
                _ => new Vector2(-SpawnPositionX, SpawnPositionY)
            };
            // Vector2 offsetVectorX = new(offsetX, 0.0f);
            // Vector2 offsetVectorY = new(0.0f, offsetY);
            // if (i > 2)
            // {
            //     // odd index after 3 spawn point are to the right
            //     if (i % 2 != 0)
            //     {
            //         _spawnPoints[i].position = new Vector2(SpawnPositionX, _spawnPoints[i].position.y);
            //     }
            //     // even index after 3 spawn point are to the left
            //     else
            //     {
            //         _spawnPoints[i].position = new Vector2(-SpawnPositionX, _spawnPoints[i].position.y);
            //         // offsetY += 3;
            //     }
            //     // _spawnPoints[i].position += (Vector3)offsetVectorY;
            // }
            // // spawn above the player
            // else
            // {
            //     _spawnPoints[i].position = new Vector2(_spawnPoints[i].position.x, SpawnPositionY);
            //     // offsetX += 3;
            // }
            // _spawnPoints[i].position += (Vector3)offsetVectorX;
        }
        // reset the offsets afte each loop iteration
    //    offsetX = -3;
    //    offsetY = -3;
    }
}
