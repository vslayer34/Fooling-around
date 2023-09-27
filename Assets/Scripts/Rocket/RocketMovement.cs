using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField]
    private SO_GameTracker _gameTracker;
    [SerializeField]
    private SO_InputLink _inputLink;
    private Rigidbody2D _rb;


    //------------------Rocekt movement properties-------------
    [Header("Rocket movement settings")]
    [SerializeField, Tooltip("Minimum speed")]
    private float _launchForceMinSpeed;

    [SerializeField, Tooltip("Maximum speed")]
    private float _launchForceMaxSpeed;

    [SerializeField, Tooltip("time to reach max speed")]
    private float _accerelationTime;
    [SerializeField, Tooltip("rotation speed")]
    private float _rotationSpeed;

    [SerializeField]
    private float _currentSpeed;
    
    //---------------------------max speed-----------------------------
    // IMPORTANT: for not spiraling out of control


    [Header("Max speed properties"), Space(5)]

    [SerializeField, Tooltip("Max Speed for the rocket")]
    private float _maxSpeed;
    [SerializeField, Tooltip("Max lateral Speed for the rocket")]
    private float _maxLateralSpeed;


    private bool isRocketFired;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_inputLink.launchButton != 0)
        {
            isRocketFired = true;
            LaunchRocket();
        }
        else
        {
            DecreaseAccerelation();
        }

        // keep track of the player location for the game manager
        _gameTracker.PlayerLocation = transform;
    }



    private void FixedUpdate()
    {
        ChangeRocketHeading(_inputLink.directionInput);
    }

    /// <summary>
    /// Handles the launch setting for the rocket
    /// </summary>
    private void LaunchRocket()
    {
        Vector2 _launchVector = _rb.transform.up * _currentSpeed;
        _rb.AddForce(_launchVector, ForceMode2D.Force);
        
        IncreaseAccerelation();
        
        // prevent the rocket from going at speeds out of the control
        if (_rb.velocity.y > _maxSpeed)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _maxSpeed);
        }
        if (_rb.velocity.x > _maxLateralSpeed)
        {
            _rb.velocity = new Vector2(_maxLateralSpeed, _rb.velocity.y);
        }
    }

    //-----------------------------accerelation---------------------------------------
    private void IncreaseAccerelation()
    {
        if (_currentSpeed > _launchForceMaxSpeed)
        {
            return;
        }

        float accerelation = (_launchForceMaxSpeed - _launchForceMinSpeed) / _accerelationTime;
        // Debug.Log(accerelation);
        _currentSpeed += accerelation * Time.fixedDeltaTime;
    }

    private void DecreaseAccerelation()
    {
        if (_currentSpeed < _launchForceMinSpeed)
        {
            _currentSpeed = _launchForceMinSpeed;
            return;
        }

        float accerelation = (_launchForceMaxSpeed - _launchForceMinSpeed) / _accerelationTime;
        // Debug.Log(accerelation);
        _currentSpeed -= accerelation * Time.fixedDeltaTime;
    }
    //-----------------------------accerelation---------------------------------------

    private void ChangeRocketHeading(float direction)
    {
        // Debug.Log($"Rocket Rotation: {rocketRotation}");
        // Debug.Log($"transform.rotation.z: {transform.rotation.z}");
        float rocketRotation = direction * Time.deltaTime * _rotationSpeed;
        
        transform.Rotate(0.0f, 0.0f, rocketRotation);
    }

    private void ChangeValueOverTime()
    {
        // Mathf.
    }
}
