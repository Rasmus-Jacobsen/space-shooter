using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void startGame() // om vi trycker på start så ändras scenen till SampleScene
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void exitGame() // om vi trycker på exit så stängs spelet ner
    { 
     Application.Quit();
    }
}
