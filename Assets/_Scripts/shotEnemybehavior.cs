using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotEnemybehavior : SteerableBehaviour
{

  private Vector3 direction;
  GameManager gm;

  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("enemy") || collision.CompareTag("enemyShoot") ) return;

      IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
      if (!(damageable is null))
      {
          damageable.TakeDamage();
      }
      Destroy(gameObject);
      if (collision.CompareTag("parede")) {
          Destroy(gameObject);
      };
  }

  void Start()
  {
      gm = GameManager.GetInstance();
  }

  void Update()
  {
      if ( gm.gameState == GameManager.GameState.GAME)
      {
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
        Thrust(direction.x, direction.y);
     }else if(gm.gameState == GameManager.GameState.MENU){
          
        Destroy(gameObject);
          
      }
  }
  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}
