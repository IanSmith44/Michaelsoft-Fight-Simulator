using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool onDead = false;
    public bool dying = false;
    [SerializeField] private healthBar healthBar;
    [SerializeField] private Rigidbody2D enemrb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Collider2D left;
    [SerializeField] private Collider2D right;
    [SerializeField] private bool grounded;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpStrength= 10f;
    public int maxHealth = 100;
    public float currentHealth;
    private Vector2 move;
    public Camera camera1;
    public Camera camera2;
    [SerializeField] private fight fightScrip;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        Time.timeScale = 0f;
        camera1.enabled = false;
        camera2.enabled = true;
    }
    void cameraShow()
    {
        healthBar.SetMaxHealth(maxHealth);
        enemrb.velocity = new Vector2(0f, 0f);
        Time.timeScale = 1f;
        camera1.enabled = true;
        camera2.enabled = false;
    }
    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.performed && grounded)
        {
            if(!fightScrip.coolingdown)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength / 2);
            }
        }
        cameraShow();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(!onDead)
        {
            move = context.ReadValue<Vector2>();
        }
        else{
            move = Vector2.zero;
        }
    }
    void Update()
    {
        if(currentHealth <= 0 && !onDead)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.angularVelocity = 3500f;
            onDead = true;
        }
        healthBar.SetPlayerHealth((int)currentHealth);
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Swap enabled state to opposite one provided that only is on at a time
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
        if(move.x < -0.01)
        {
            sr.flipX = true;
            left.enabled = true;
            right.enabled = false;
        }
        else if(move.x > 0.01)
        {
            sr.flipX = false;
            left.enabled = false;
            right.enabled = true;
        }
        if(!fightScrip.coolingdown)
        {
            rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(move.x * (moveSpeed / 2), rb.velocity.y);
        }
    }
    void FixedUpdate()
    {
        if(dying)
        {
            currentHealth -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
