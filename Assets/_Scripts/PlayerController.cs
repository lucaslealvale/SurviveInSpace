using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IDamageable, IShooter
{
    
    public float cantoDireito;
    public float cantoEsquerdo;
    public float cantoSuperior;
    public float cantoInferior;

    public GameObject bullet;
    public GameObject bullet2;

    public Transform arma; 
    Animator animator;
    public float shootDelay = 0.1f;
    public AudioClip shootSFX;
    private float _lastShootTimestamp = 0.0f;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();
    }
   

    public void TakeDamage()
    {
       gm.vidas--;

       if (gm.vidas <= 0){
        Die();   
        };
       if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
    {
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }       
    }

    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }


    public void Shoot()
    {
        
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        audioManeger.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        if(gm.nivelArma==0){
        Instantiate(bullet, arma.position, Quaternion.identity);
        }else{
            Instantiate(bullet2, arma.position, Quaternion.identity);
        }
    }

   void FixedUpdate()
   {    
       if(gm.gameState != GameManager.GameState.GAME) return;
       
       float yInput = Input.GetAxis("Vertical");
       float xInput = Input.GetAxis("Horizontal");
       
       

       if(transform.position.x < cantoEsquerdo && xInput < 0 || transform.position.x > cantoDireito && xInput > 0 ){
           xInput = 0;
       }
       if(transform.position.y < cantoInferior && yInput < 0 || transform.position.y > cantoSuperior && yInput > 0 ){
           yInput = 0;
       }
       
      
       
       Thrust(xInput, yInput);

       if (yInput != 0 || xInput != 0)
       {
           animator.SetFloat("velocity", 1.0f);
       }
       else
       {
           animator.SetFloat("velocity", 0.0f);
       }
      if(Input.GetAxisRaw("Jump") != 0)
       {
           Shoot();
       }
       if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
       gm.ChangeState(GameManager.GameState.PAUSE);
   }
       gm.time--;
       if(gm.time <= 0 && gm.gameState == GameManager.GameState.GAME)
    {

        gm.ChangeState(GameManager.GameState.ENDGAME);
        Die();
    }
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("enemy"))
    {
        Destroy(collision.gameObject);
        TakeDamage();
    }
    if (collision.CompareTag("pedra"))
    {
        Destroy(collision.gameObject);
        
        TakeDamage();
    }
    if (collision.CompareTag("superArma"))
    {
        gm.nivelArma=1;
        Destroy(collision.gameObject);

    }
    }
  
    
    
}
