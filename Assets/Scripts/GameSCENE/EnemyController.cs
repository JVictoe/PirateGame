using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private Transform[] spaws = default;
    [SerializeField] private GameObject[] enemies = default;

    private bool endGame;

    List<BoatEnemy> enemiesList;

    private void Start()
    {
        enemiesList = new();

        InvokeRepeating(nameof(CreateEnemy), 0f, GameManager.Match.SpawTime);
    }

    private void CreateEnemy()
    {
        BoatEnemy enemyAux = Instantiate(enemies[Random.Range(0, enemies.Length)], spaws[Random.Range(0, spaws.Length)].position, transform.rotation).GetComponent<BoatEnemy>();
        enemyAux.SetTarget(target);

        enemiesList.Add(enemyAux);
    }

    public void StopCreate()
    {
        if(!endGame)
        {
            endGame= true;
            CancelInvoke(nameof(CreateEnemy));

            foreach (var enemy in enemiesList) Destroy(enemy);
        }
    }
}
