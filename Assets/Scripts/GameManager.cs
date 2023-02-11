using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Constants;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static GameState state = GameState.StartMenu;

    void Awake()
    {
        // Debug.Log("awake!");
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //ChangeStateEvent += ChangeState;
        //SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    /*private void OnDestroy()
    {
        ChangeStateEvent -= ChangeState;
        GetStateEvent -= GetState;
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }*/

    public static void SetGameState(GameState newState) {
        state = newState;
    }

    public static GameState GetGameState()
    {
        return state;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1280, 720, true);
        state = GameState.StartMenu;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case GameState.StartMenu:
                // Start Menu
                Debug.Log(GameState.StartMenu.ToString());
                if (SceneManager.GetActiveScene().name != GameState.StartMenu.ToString())
                {
                    SceneManager.LoadScene(GameState.StartMenu.ToString());
                }
                break;
            case GameState.NewGame:
                // New Game
                // Reset level
                if (SceneManager.GetActiveScene().name != GameState.NewGame.ToString())
                {
                    //Time.timeScale = 1f;
                    SceneManager.LoadScene(GameState.NewGame.ToString());
                }
                break;
            case GameState.WinGame:
                // Win Game
                if (SceneManager.GetActiveScene().name != GameState.WinGame.ToString())
                {
                    SceneManager.LoadScene(GameState.WinGame.ToString());
                }
                break;
            case GameState.LoseGame:
                //Debug.Log("LoseGame");
                if (SceneManager.GetActiveScene().name != GameState.LoseGame.ToString())
                {
                    SceneManager.LoadScene(GameState.LoseGame.ToString());
                }
                break;
        }
    }

}