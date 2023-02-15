using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerde_mi : MonoBehaviour
{
    public LayerMask layer;
    public bool yerde_miyiz;
    public Rigidbody2D rb;
    public float speed = 8f;  
    void Update()
    {
        if (player.oyun_basladi_mi==false)
        {
            return;
        }
        RaycastHit2D carpýyor_mu = Physics2D.Raycast(transform.position,Vector2.down,0.15f,layer);
        if (carpýyor_mu.collider !=null)
        {       
            yerde_miyiz = true;
        }
        else
        {           
            yerde_miyiz = false;
        }
     
        if (yerde_miyiz == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }


    }

   



}
