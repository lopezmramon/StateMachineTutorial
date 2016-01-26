using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum GameState {

        MainMenu,
        OptionsMenu,
        SinglePlayerMenu,

    }
    public GameState currentGameState;
    Canvas MainMenuCanvas, OptionsMenuCanvas, SinglePlayerMenuCanvas;
    

	void Start () {
        MainMenuCanvas = GameObject.Find("MainMenu").gameObject.GetComponent<Canvas>();
        OptionsMenuCanvas = GameObject.Find("OptionsMenu").gameObject.GetComponent<Canvas>();
        SinglePlayerMenuCanvas = GameObject.Find("SinglePlayerMenu").gameObject.GetComponent<Canvas>();
        ChangeState(GameState.MainMenu);
	}
	
	void Update () {
	
	}

    public void ChangeState(GameState newState)
    {
        currentGameState = newState;
        StartCoroutine(newState.ToString() + "State");

    }

    //Game States

    IEnumerator MainMenuState()
    {
        MainMenuCanvas.enabled = true;
        while (currentGameState == GameState.MainMenu)
        {
            yield return null;

        }
        MainMenuCanvas.enabled = false;
    }
    IEnumerator OptionsMenuState()
    {
        OptionsMenuCanvas.enabled = true;
        while (currentGameState == GameState.OptionsMenu)
        {
            yield return null;

        }
        OptionsMenuCanvas.enabled = false;


    }
    IEnumerator SinglePlayerMenuState()
    {
        SinglePlayerMenuCanvas.enabled = true;
        while (currentGameState == GameState.SinglePlayerMenu)
        {
            yield return null;

        }
        SinglePlayerMenuCanvas.enabled = false;


    }
}
