using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float sceneradius = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -sceneradius)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > sceneradius)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -sceneradius)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > sceneradius)
        {
            Destroy(gameObject);
        }

    }


}

