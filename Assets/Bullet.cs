using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 20f;
    Rigidbody2D rb;
    [SerializeField, Range(0.005f, 25)] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoints hit = collision.gameObject.GetComponent<hitPoints>();
        if (hit != null)
        {
            hit.TakeDamage(damageAmount);
        }
        if (collision.gameObject.tag =="Border")
        {
            Destroy(gameObject);
        }
    }
}
