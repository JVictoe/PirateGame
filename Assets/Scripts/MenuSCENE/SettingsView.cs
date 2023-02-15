using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsView : MonoBehaviour
{
    [SerializeField] private CanvasGroup cv = default;
    [SerializeField] private GraphicRaycaster raycaster = default;

    [SerializeField] private Button closeButton = default;

    [SerializeField] private TextMeshProUGUI matchTime = default;
    [SerializeField] private TextMeshProUGUI spawTime = default;

    private void Start()
    {
        closeButton.onClick.AddListener(ClosePanel);
    }

    public void ShowPanel()
    {
        SetCanvas(true);
    }

    private void ClosePanel()
    {
        SetCanvas(false);

        float matchDuration = 1;
        float spawTimeRepeat = 4;

        if (matchTime.text.Equals("1 minuto"))
        {
            matchDuration = 1f;
        }
        else if(matchTime.text.Equals("2 minutos"))
        {
            matchDuration = 2f;
        }
        else if(matchTime.text.Equals("3 minutos"))
        {
            matchDuration = 3f;
        }

        if (spawTime.text.Equals("4 segundos"))
        {
            spawTimeRepeat = 4f;
        }
        else if (spawTime.text.Equals("6 segundos"))
        {
            spawTimeRepeat = 6f;
        }
        else if (spawTime.text.Equals("8 segundos"))
        {
            spawTimeRepeat = 8f;
        }

        GameManager.Match.MatchDuration = matchDuration;
        GameManager.Match.SpawTime = spawTimeRepeat;
    }

    private void SetCanvas(bool open)
    {
        cv.DOFade(open ? 1 : 0, 0.3f);
        cv.interactable = open;
        cv.blocksRaycasts = open;
        raycaster.enabled = open;
    }
}
