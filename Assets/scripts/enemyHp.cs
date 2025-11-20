using UnityEngine;

public class enemyHp : MonoBehaviour
{
    int maxHippoints = 10;
    int currentHippoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHippoints = maxHippoints;  // sätter fiendens hp till max hp när den spawnas
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision) // om den träffs av ett skott så tar den skada
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
