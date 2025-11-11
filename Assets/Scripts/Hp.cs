using UnityEngine;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    [SerializeField]
    int maxHp = 100;
    int currentHp;
    int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Bullet"))
        {
            currentHp -= damage;
            Debug.Log("Player HP: " + currentHp);
            if (currentHp <= 0)
            {
                Destroy(gameObject);
               SceneManager.LoadScene("Death.Scene");
                Debug.Log("Game Over");
            }
        }
    }
}
