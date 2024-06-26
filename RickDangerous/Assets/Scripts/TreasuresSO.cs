using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreasuresStatus", menuName = "TreasuresStatus")]

public class TreasuresSO : ScriptableObject
{
    //[SerializeField] private AudioSource treasureSound;
    [SerializeField] private int treasureValue;
    private int valueToIncrease;
    [SerializeField] private AudioClip treasureClip;

    public int TreasureValue
    {
        get { return treasureValue; }
        set { treasureValue = value; }
    }

    public AudioClip TreasureClip{

        get { return treasureClip; }
    }
}
