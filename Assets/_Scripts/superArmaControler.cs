using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superArmaControler : SteerableBehaviour,  IDamageable
{
    // public GameObject tiro;
    // public GameObject superArma;
    GameManager gm;
    // public AudioClip shootSFX;

    private void Start()
    {
        gm = GameManager.GetInstance();

    }
    // public void Shoot()
    // {
    // // audioManeger.PlaySFX(shootSFX);

    // Instantiate(tiro, transform.position, Quaternion.identity);    }

    public void TakeDamage()
    {
       Die();
    }

    public void Die()
    {
        float a =  Random.Range(0.0f,10.0f);
       
        Destroy(gameObject);
        gm.pontos+=10;
        
        
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
