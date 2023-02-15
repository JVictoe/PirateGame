using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    shooter,
    chaser
}

public class BoatEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = default;
    [SerializeField] private Transform target = default;

    [SerializeField] private AiCannon aiCannon = default;

    [SerializeField] private BoatAiLifeUi boatLife = default;

    [SerializeField] private EnemyType enemyType = default;
    [SerializeField] private float meleeDamage = default;

    public bool shooting;

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        enemyType = (EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
        meleeDamage = UnityEngine.Random.Range(20, 25);
    }

    public float GetDamage => meleeDamage;
    public void SetTarget(Transform target) { this.target = target; }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (enemyType == EnemyType.shooter)
            {
                float distance = Vector3.Distance(target.position, transform.position);

                if (distance <= agent.stoppingDistance)
                {
                    agent.isStopped = true;

                    if (!shooting)
                    {
                        StartCoroutine(AiShoot());
                    }
                }
                else
                {
                    agent.isStopped = false;
                }
            }
            else if (enemyType == EnemyType.chaser)
            {
                agent.isStopped = false;
                agent.stoppingDistance = 0;
            }

            agent.SetDestination(target.position);
        }
    }

    IEnumerator AiShoot()
    {
        shooting = true;
        aiCannon.Shoot();

        yield return new WaitForSeconds(2f);

        shooting = false;
    }

    public void GetHit(float damage)
    {
        if (boatLife.GetHit(damage))
        {
            Boat.instance.Points = 1;
            Destroy(gameObject);
        }
    }
}
