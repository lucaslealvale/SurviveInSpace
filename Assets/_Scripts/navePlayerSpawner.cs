using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navePlayerSpawner : MonoBehaviour
{
  public GameObject navePlayer;
  GameManager gm;

  void Start()
  {
      gm = GameManager.GetInstance();
      // GameManager.changeStateDelegate += Construir;
    
      Construir();
      Debug.Log($"{navePlayer}");
  }

  void Construir()
  {
      Debug.Log($"criando: {gm.gameState}");
      

      GameObject tile = Instantiate(navePlayer, gm.position, Quaternion.identity, transform);
      }
  

  void Update()
  {
      if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
      {
          gm.ChangeState(GameManager.GameState.ENDGAME);

      }
      if (GameObject.FindWithTag("Player") == null && gm.gameState == GameManager.GameState.GAME)
      {
          Construir();

      }
        
  }
 
}

