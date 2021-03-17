using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_MenuPrincipal : MonoBehaviour
{
  GameObject nave;
  GameManager gm;
  SpriteRenderer sR;

  void Start()
  {
    nave = GameObject.FindWithTag("Player");
    sR = nave.GetComponent<SpriteRenderer>();
    
  }

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Comecar()
  {
      gm.ChangeState(GameManager.GameState.GAME);
      sR.enabled = true; 
      nave.transform.position = gm.position;

  }
}