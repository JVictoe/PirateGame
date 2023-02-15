using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playGame = default;
    [SerializeField] private Button settings = default;
    [SerializeField] private SettingsView settingsView = default;

    private void Start()
    {
        playGame.onClick.AddListener(LoadGame);
        settings.onClick.AddListener(OpenSettings);
    }

    private void LoadGame()
    {
        GameManager.Scene.LoadScene(SceneEnum.game);
    }

    private void OpenSettings()
    {
        settingsView.ShowPanel();
    }
}
