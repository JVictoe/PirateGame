using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private ScenesManager scene = default;
    public static ScenesManager Scene { get { return instance.scene; } }

    [SerializeField] private MatchManager match = default;
    public static MatchManager Match { get { return instance.match; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        Application.targetFrameRate = 60;
    }
}
