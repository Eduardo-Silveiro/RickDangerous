using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBoxes", menuName = "BulletBoxes")]

public class BulletBoxesSO : ScriptableObject
{
    [SerializeField] private int numberOfAmmoGiven;

    public int NumberOfAmmoGiven { 
        get { return numberOfAmmoGiven; }
        set { numberOfAmmoGiven = value; }
    }
}
