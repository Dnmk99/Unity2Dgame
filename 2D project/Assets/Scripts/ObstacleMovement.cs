using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Animator anim;
    
    public Vector2 startPos;

    // Start is called before the first frame update
    public void Start()
    {
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("bombsReset"))
        {
            gameObject.transform.position = startPos;


        }
        else if (collision.gameObject.CompareTag("bombsReset"))
        {
            anim.SetTrigger("Boom");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.position = startPos;
            
        }
    }
}
