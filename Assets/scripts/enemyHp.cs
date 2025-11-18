using UnityEngine;

public class enemyHp : MonoBehaviour
{
    int maxHippoints = 10;
    int currentHippoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHippoints = maxHippoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHippoints -= 10;
            if (currentHippoints <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
