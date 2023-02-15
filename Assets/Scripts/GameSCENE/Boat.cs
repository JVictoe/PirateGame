using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class Boat : MonoBehaviour
{
    public static Boat instance;

    [SerializeField] private Rigidbody2D rb = default;
    [SerializeField] private float speed = default;
    [SerializeField] private float rotationSpeed = default;
    [SerializeField] private float driftFactor = default;
    [SerializeField] private float dragFactor = default;
    [SerializeField] private float maxSpeed = default;

    [SerializeField] private BoatLifeUi boatLife = default;
    [SerializeField] private EndGameView endGameView = default;
    [SerializeField] private EnemyController enemyController = default;

    [SerializeField] private TextMeshProUGUI pointsUiText = default;

    [SerializeField] private GameObject explosion = default;

    private Vector2 move;
    private float rotationAngle;

    private int points;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        move.x = Input.GetAxis("Vertical");
        move.y = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        ApplySpeed();
        ApplyRotation();
        ApplyDrifit();
    }

    #region MOVIMENT
    private void ApplySpeed()
    {
        if(move.x == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, dragFactor, Time.fixedDeltaTime);
        }
        else
        {
            rb.drag = 0;
        }

        float velocityUp = Vector2.Dot(transform.up, rb.velocity);

        if (velocityUp > maxSpeed) return;
        if (velocityUp < (-maxSpeed * 0.5f)) return;

        rb.AddForce(transform.up * speed * move.x, ForceMode2D.Force);
    }

    private void ApplyRotation()
    {
        rotationAngle = rotationAngle - (move.y * rotationSpeed);
        rb.MoveRotation(rotationAngle);
    }

    private void ApplyDrifit()
    {
        Vector2 velocityUp = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 velocityRight = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = velocityUp + velocityRight * driftFactor;
    }

    #endregion

    public void GetHit(float damage)
    {
        if(boatLife.GetHit(damage))
        {
            endGameView.ShowPanel(false);
            enemyController.StopCreate();
            Destroy(gameObject);
        }
    }

    public void EndGame()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoatEnemy enemy = collision.gameObject.GetComponent<BoatEnemy>();

        if (enemy != null)
        {
            GetHit(enemy.GetDamage);
            StartExplosion(enemy.transform.position);
            Destroy(enemy.gameObject);
        }
    }

    private void StartExplosion(Vector3 position)
    {
        GameObject obj = Instantiate(explosion, position, Quaternion.identity);
        Destroy(obj, 0.5f);
    }

    public int Points { get { return points; } set { points += value; pointsUiText.text = "Pontos: " + points.ToString(); } }
}
