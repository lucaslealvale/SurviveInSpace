using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehavior : SteerableBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();

    }
    float angle = 0;

   private void FixedUpdate()
   {
       if(gm.gameState != GameManager.GameState.GAME) return;

       angle += 0.1f;
       if (angle > 2.0f * Mathf.PI) angle = 0.0f;
       Thrust(0, Mathf.Cos(angle));
   }
   

}
