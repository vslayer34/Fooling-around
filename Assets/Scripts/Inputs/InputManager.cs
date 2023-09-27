using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private SO_InputLink _inputLink;

    private RocketController _rocketController;
    private InputAction _movementAction;
    private InputAction _launchAction;
    private InputAction _shootAction;


    private void Awake()
    {
        _rocketController = new RocketController();   
        _movementAction = _rocketController.Rocket.Movement;
        _launchAction = _rocketController.Rocket.Launch;
        _shootAction = _rocketController.Rocket.Shoot;
    }

    private void Start()
    {
        _rocketController.Enable();
        _shootAction.performed += ctx => _inputLink.OnShoot?.Invoke();
    }


    private void Update()
    {
        _inputLink.directionInput = _rocketController.Rocket.Movement.ReadValue<float>();
        _inputLink.launchButton = _rocketController.Rocket.Launch.ReadValue<float>();
    }
}
