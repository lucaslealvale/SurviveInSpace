using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
   private static GameManager _instance;
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };

   public GameState gameState { get; private set; }
   public int vidas;
   public int pontos;
   public int time;
   public  Vector3 position;
   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }
   private GameManager()
   {
       vidas = 10;
       pontos = 0;
       time = 6000;
       position = new Vector3(-5.25f,-4.0f,0);
       gameState = GameState.MENU;
   }
    public delegate void ChangeStateDelegate();

    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
       if (nextState == GameState.GAME) Reset();
        
        if(gameState == GameState.PAUSE && nextState == GameState.MENU){
            GameObject.FindWithTag("Player").transform.position = position;
        }
        
        gameState = nextState;
        
        changeStateDelegate();
        
    }

    private void Reset()
    {
    vidas = 10;
    pontos = 0;
    time = 6000;

    }
}