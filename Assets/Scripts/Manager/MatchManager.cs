using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private float matchDuration;
    [SerializeField] private float spawTime;

    private void Start()
    {
        MatchDuration = 1;
        SpawTime = 4;
    }

    public float MatchDuration
    {
        get { return matchDuration; }
        set { matchDuration = value; }
    }

    public float SpawTime
    {
        get { return spawTime; }
        set { spawTime = value; }
    }
}
