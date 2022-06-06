using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject DeathMenuUI;
    public static bool GamePaused = false;
    private static bool playerDead = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death_fall"))
        {
            Death();
            
        }
    }
    private void Death()
    {
        anim.SetTrigger("isDead");
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
