using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] int speed = 2;
    int timer = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
      
    }
}
