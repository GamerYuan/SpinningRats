using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class PlayerLogic : MonoBehaviour
{
    private RatsCount ratCount;

    private void Awake()
    {
        this.ratCount = GetComponent<RatsCount>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.ratCount.IsLosingRatCount()) 
        {
            GameManager.SetGameState(GameState.LoseGame);
            Destroy(this.gameObject);
        }
        if (this.ratCount.IsWinningRatCount()) {
            GameManager.SetGameState(GameState.WinGame);
            Destroy(this.gameObject);
        }
    }

}
