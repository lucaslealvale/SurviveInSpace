using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject tiro;
    public GameObject points;

    public GameObject superArma;
    GameManager gm;
    public AudioClip shootSFX;
    private int vidas = 2;
    private void Start()
    {
        gm = GameManager.GetInstance();

    }
    public void Shoot()
    {
    audioManeger.PlaySFX(shootSFX);

    Instantiate(tiro, transform.position, Quaternion.identity);    }

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
        float a =  Random.Range(0.0f,5.0f);
        if( a <= 1.0f){
            Instantiate(superArma, transform.position, Quaternion.identity);
            }
        Destroy(gameObject);
        gm.pontos+=10;
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
