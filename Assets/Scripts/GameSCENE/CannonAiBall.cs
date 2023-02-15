using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAiBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = default;
    [SerializeField] private float speed = default;
    [SerializeField] private GameObject explosion = default;
    [SerializeField] private float damage = default;

    private void Start()
    {
        damage = Random.Range(10, 20);
    }

    public void AddVelocity(int multiply)
    {
        rb.AddForce((transform.right * multiply) * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boat boat = collision.GetComponent<Boat>();
        if (boat != null)
        {
            boat.GetHit(damage);
            StartExplosion();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartExplosion();
        }
    }

    private void StartExplosion()
    {
        rb.velocity = Vector2.zero;
        GameObject obj = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(obj, 0.5f);
        Destroy(gameObject);
    }
}
