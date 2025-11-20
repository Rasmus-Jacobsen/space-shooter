using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] int speed = 2; // hastigheten fienden rör sig med
    int timer = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0) // om timer 0 så rör sig fienden neråt
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime); // gör så att fienden åker rakt ner 
        }
      
    }
}
