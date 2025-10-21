using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Wepaon : MonoBehaviour
{
    KeyCode bullet = KeyCode.Space;
    [SerializeField] GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(bullet))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Debug.Log("bullet created");
        }




    }
}