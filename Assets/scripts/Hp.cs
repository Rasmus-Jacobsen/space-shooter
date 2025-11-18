using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class Hp  : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    int maxHealth = 100;
    int currentHealth;
    public GameObject deathScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        deathScene.SetActive(false);

        hpText.text = currentHealth.ToString();
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
                deathScene.SetActive(true);
            }
            if (gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
