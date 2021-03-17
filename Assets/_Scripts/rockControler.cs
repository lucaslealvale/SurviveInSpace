using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rockControler : SteerableBehaviour, IDamageable
{
   public GameObject points;
    private int vidas = 3;
    GameManager gm;
    // public AudioClip shootSFX;

    private void Start()
    {
        gm = GameManager.GetInstance();

    }
    public void TakeDamage()
    {
       if(gm.nivelArma==0){
       vidas--;

       if (vidas <= 0){
            Die();   
            };
       
       }else{
        vidas-=2;
       if (vidas <= 0){
            Die();   
            };
        }
         
    }

    public void Die()
    {
        Destroy(gameObject);
        gm.pontos+=30;
        Instantiate(points, transform.position, Quaternion.identity);
    }
    float angle = 0;

    private void FixedUpdate()
    {
        
        if (gm.gameState != GameManager.GameState.GAME) return;
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        // Thrust(x, y);
    }
}