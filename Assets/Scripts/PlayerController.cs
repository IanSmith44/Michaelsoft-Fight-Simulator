using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Collider2D left;
    [SerializeField] private Collider2D right;
    [SerializeField] private bool grounded;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpStrength= 10f;
    private Vector2 move;
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        Time.timeScale = 0f;
        camera1.enabled = false;
        camera2.enabled = true;
    }
    void cameraShow()
    {
        Time.timeScale = 1f;
        camera1.enabled = true;
        camera2.enabled = false;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        cameraShow();
        if (context.performed && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    void Update()
    {
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
        rb.velocity = new Vector2(move.x * moveSpeed, rb.velocity.y);
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
