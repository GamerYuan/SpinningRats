using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class MenuLogic : MonoBehaviour
{

    public void StartGame() {
        GameManager.SetGameState(GameState.NewGame);
    }

    public void RestartGame() {
        GameManager.SetGameState(GameState.NewGame);
    }

    public void StartMenu() {
        GameManager.SetGameState(GameState.StartMenu);
    }

}