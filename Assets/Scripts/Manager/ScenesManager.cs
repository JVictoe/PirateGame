using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneEnum
{
    menu,
    game
}

public class ScenesManager : MonoBehaviour
{
    public void LoadScene(SceneEnum @enum)
    {
        SceneManager.LoadSceneAsync((int)@enum);
    }
}
