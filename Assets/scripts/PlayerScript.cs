using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 5f; // fart för spelaren
    [SerializeField] KeyCode moveLeft = KeyCode.A; 
    [SerializeField] KeyCode moveRight = KeyCode.D;
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    public GameObject bullet;
    public GameObject muzzle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveLeft)) // om vi trycker på vänster knapp så rör sig spelaren åt vänster
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); 
        }
        if (Input.GetKey(moveRight)) // om vi trycker på höger knapp så rör sig spelaren åt höger
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(shootKey)) // om vi trycker på skjut knappen så skjuter vi ett skott
        {
            Instantiate(bullet, muzzle.transform).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500f);
        }
    }
}
