using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(0.005f, 25)] float speed;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            print(left);
            transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            print(right);
            transform.position += new Vector3(1, 0, 0) * speed* Time.deltaTime;

        }  
    }
 }     
