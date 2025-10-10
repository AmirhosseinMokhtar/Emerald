using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool canJump;
    public bool gameOver;
    public bool gamePaused;
    public bool gameResume;

    //public enum GameState { gameOver, gamePause, gameResume }
    //public GameState state;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(gameOver);
        //if (state == GameState.gamePause)
        //{
        //    Debug.Log("Game Paused");
        //}
        //else if (state == GameState.gamePause)
        //{
        //    Debug.Log("Game Resumed");
        //}
        //else if (state == GameState.gameOver)
        //{
        //    Debug.Log("Game Over");
        //}
    }

    public void CheckGameState()
    {
        //Debug.Log(state.ToString());
        //if (state == GameState.gamePause)
        //{
        //    Debug.Log("Game Paused");
        //}
        //else if (state == GameState.gamePause)
        //{
        //    Debug.Log("Game Resumed");
        //}
        //else if (state == GameState.gameOver)
        //{
        //    Debug.Log("Game Over");
        //}
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
