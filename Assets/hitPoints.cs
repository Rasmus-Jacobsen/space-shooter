using UnityEngine;
using UnityEngine.SceneManagement;

public class hitPoints : MonoBehaviour
{
    [SerializeField, Range(0.5f, 25)] float maxHp;
    private float currentHealth;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHp;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;

        
            Debug.Log("Damage taken");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDie();
                Debug.Log("Death");
            }
        
    }










    private void OnDie()
    {
        if (gameObject.CompareTag("player"))
        SceneManager.LoadScene(1);
        Debug.Log("Change scene");



    }


}







