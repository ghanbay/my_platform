using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerde_mi : MonoBehaviour
{
    public LayerMask layer;
    public bool yerde_miyiz;
    public Rigidbody2D rb;
    public float speed = 8f;

    void Start()
    {
        
    }

    void Update()
    {
        if (player.oyun_basladi_mi==false)
        {
            return;
        }
        RaycastHit2D carp�yor_mu = Physics2D.Raycast(transform.position,Vector2.down,0.15f,layer);
        if (carp�yor_mu.collider !=null)
        {
            //zemine �arp�yor
            yerde_miyiz = true;
        }
        else
        {
            //havaday�z
            yerde_miyiz = false;
        }
        //klavyeden tu�a ba�ma input ile yap�l�r. tu�a basma getkeydown ile kullan�l�r.
        if (yerde_miyiz == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }


    }

   



}
