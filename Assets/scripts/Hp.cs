using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Hp  : MonoBehaviour
{
    int maxHealth = 100;
    int currentHealth;
    public GameObject deathScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        deathScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 20;
            if (currentHealth <= 0)
            {
                
                Destroy(gameObject);
                
            }
            if (gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
