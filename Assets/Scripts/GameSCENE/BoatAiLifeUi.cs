using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoatAiLifeUi : MonoBehaviour
{
    [SerializeField] private Slider sliderLife = default;
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float force = 0.1f;

    [SerializeField] private SpriteRenderer mainBoat = default;

    [SerializeField] private Sprite[] boat = default;
    [SerializeField] private GameObject[] fires = default;

    public bool GetHit(float value)
    {
        float currentValue = sliderLife.value;

        currentValue -= value;

        sliderLife.DOValue(currentValue, 0.5f);
        sliderLife.transform.DOShakePosition(duration, force);

        if (currentValue >= 75)
        {
            mainBoat.sprite = boat[0];
        }
        else if (currentValue >= 50)
        {
            mainBoat.sprite = boat[1];
        }
        else if (currentValue >= 25)
        {
            foreach (var item in fires) item.SetActive(true);
            mainBoat.sprite = boat[2];
        }
        else if (currentValue >= 0)
        {
            mainBoat.sprite = boat[3];
        }

        return currentValue <= 0;
    }
}
