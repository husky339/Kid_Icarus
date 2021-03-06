﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public bool isFacingRight;

    Animator anim;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (!rb)
        {
            Debug.LogWarning("No Rigidbody 2D found...");
        }
        if (!sr)
        {
            Debug.LogWarning("No SpriteRenderer found...");
        }
        if (speed <= 0)
        {
            speed = 5.0f;

            Debug.LogWarning("Speed defaulted to 5");
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (health <= 0)
        {
            health = 5;
            Debug.Log("Enemy: Defaulting health to " + health);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BarrierLeft")
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (collision.gameObject.tag == "BarrierRight")
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if (collision.gameObject.tag == "BarrierUp")
        {
            rb.velocity = new Vector2(0, speed);
        }
        if (collision.gameObject.tag == "BarrierDown")
        {
            rb.velocity = new Vector2(0, -speed);
        }


    }
    void OnCollisionEnter2D(Collision2D c)
    {
        // Did GameObject tagged ”Projectile” hit Enemy
        if (c.gameObject.tag == "Projectile")
        {
            // Destroy Projectile that collided
            Destroy(c.gameObject);
            health -= 1; // Remove 1 health on Collision
                         // Check if health is ZERO
            if (health <= 0)
            {
                anim.SetBool("isDead", true);
                // Destroy GameObject Script is attached to
                // when health is ZERO (Enemy)
            }
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
