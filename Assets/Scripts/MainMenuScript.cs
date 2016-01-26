using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    GameManager gameManager;
    
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();


    }
    public void Options()
    {

        gameManager.ChangeState(GameManager.GameState.OptionsMenu);
    }
    public void SinglePlayer()
    {
        gameManager.ChangeState(GameManager.GameState.SinglePlayerMenu);


    }
    public void Quit()
    {
        Debug.Log("This doesn't work in the Editor. Outside of it, the game was closed");
        Application.Quit();
        
    }
}
