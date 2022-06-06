using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    public void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death_fall") || collision.gameObject.CompareTag("bombsReset"))
        {
            anim.SetTrigger("Boom");
        }
    }
}
