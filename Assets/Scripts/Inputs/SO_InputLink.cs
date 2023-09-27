using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new input link", menuName = "Managers/input")]
public class SO_InputLink : ScriptableObject
{
    public Action OnShoot;
    public float directionInput;
    public float launchButton;


}
