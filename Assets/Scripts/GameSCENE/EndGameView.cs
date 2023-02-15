using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;
using System.Net.NetworkInformation;

public class EndGameView : MonoBehaviour
{
    [SerializeField] private CanvasGroup cv = default;
    [SerializeField] private GraphicRaycaster raycaster = default;

    [SerializeField] private GameObject gameTime = default;

    [SerializeField] private TextMeshProUGUI points = default;

    [SerializeField] private Button playAgainButton = default;
    [SerializeField] private Button menuButton = default;
    [SerializeField] private GameObject winStatus = default;

    private bool endGame;

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        menuButton.onClick.AddListener(Menu);
    }

    private void PlayAgain()
    {
        GameManager.Scene.LoadScene(SceneEnum.game);
    }

    private void Menu()
    {
        GameManager.Scene.LoadScene(SceneEnum.menu);
    }

    public void ShowPanel(bool win)
    {
        if(!endGame)
        {
            winStatus.SetActive(win);
            gameTime.SetActive(false);
            endGame = true;

            cv.DOFade(1, 1f);
            cv.interactable = true;
            cv.blocksRaycasts = true;
            raycaster.enabled = true;

            this.points.text = "Pontuação: " + Boat.instance.Points;
        }
    }
}
