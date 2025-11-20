using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;


public class Hp  : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    int maxHealth = 100;
    [SerializeField] int currentHealth;
    int damage = 20;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // startar spelet med fullt Hp
        

        
    }

    void Update()
    {
        hpText.text = "HP: " + currentHealth.ToString();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision) // om en enemy passerar backom dig så förlorar du hp
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= damage;
           
            Destroy(collision.gameObject);
            if (currentHealth <= 0)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("deathScene");
            }
        }
    }
   

}
    



