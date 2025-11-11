using UnityEngine;

public class Player: MonoBehaviour
{
    
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    public GameObject Bullet;
    public GameObject Muzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 5);
        }
        if (Input.GetKey(right))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5);

            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, Muzzle.transform).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10  , ForceMode2D.Impulse);
        }
    }
}
