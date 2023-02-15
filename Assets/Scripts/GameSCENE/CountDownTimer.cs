using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text gameTime = default;

    [SerializeField] private EndGameView endGameView = default;
    [SerializeField] private EnemyController enemyController = default;

    [SerializeField] private Boat boat = default;

    public float minutes = 1;
    public float seconds = 0;

    private float timer;
    private bool endGame;

    void Start()
    {
        minutes = GameManager.Match.MatchDuration;
        timer = minutes * 60 + seconds;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            int minutesLeft = Mathf.FloorToInt(timer / 60);
            int secondsLeft = Mathf.FloorToInt(timer % 60);

            gameTime.text = "Tempo: " + string.Format("{0:00}:{1:00}", minutesLeft, secondsLeft);
        }
        else
        {
            gameTime.text = "00:00";

            if(!endGame)
            {
                endGame = true;
                enemyController.StopCreate();
                boat.EndGame();
                endGameView.ShowPanel(true);
            }
        }
    }
}
