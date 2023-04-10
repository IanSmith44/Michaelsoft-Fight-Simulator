using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushingIsntNice : MonoBehaviour
{
    private bool dead = false;
    [SerializeField] private healthBar healthBar;
    public int health = 100;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
        if(health <= 0)
        {
            dead = true;
        }
        healthBar.SetEnemyHealth(health);
    }
    void FixedUpdate()
    {
        if(!dead)
        {
            if(rb.velocity.x > maxSpeed && player.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            else if(rb.velocity.x < -maxSpeed && player.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
            if(player.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(speed, 0f));
            }
            else if(player.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(-speed, 0f));
            }
        }
    }
}
