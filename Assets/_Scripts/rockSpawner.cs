using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawner : MonoBehaviour
{
  public GameObject pedra;
  GameManager gm;

  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();
  }

  void Construir()
  {
      
       if (gm.gameState == GameManager.GameState.GAME)
      {
        
        float c =  Random.Range(-3,7);
        float d =  Random.Range(-6,1);
        Vector3 posicao = new Vector3(c,d,0);
        GameObject tile = Instantiate(pedra, posicao, Quaternion.identity, transform);
      }else if(gm.gameState == GameManager.GameState.MENU){
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
      }
  }

  
  private void FixedUpdate()
    {
        
        float a =  Random.Range(0.0f,10.0f);
        if( a <= 0.01){
            Construir();
            }
        }
}