using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombBoxesSO", menuName = "BombBoxesSO")]

public class BombBoxesSO : ScriptableObject
{
    [SerializeField] private int numberOfBombsGiven;

    public int NumberOfBombsGiven
    {
        get { return numberOfBombsGiven; }
        set { numberOfBombsGiven = value; }
    }
}