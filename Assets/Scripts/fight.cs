using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fight : MonoBehaviour
{
    [SerializeField] private healthBar healthBar;
    private float cooldown = 0f;
    [SerializeField] private SpriteRenderer sr;
    public GameObject currentCollision;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnFight1(InputAction.CallbackContext context)
    {
        if (context.performed && currentCollision != null)
        {
            if(cooldown > 0)
            {
                return;
            }
            else if (sr.flipX)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(-5 , 5);
                currentCollision.GetComponent<pushingIsntNice>().health -= 10;
                cooldown = 0.75f;
            }
            else if (!sr.flipX)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(5 , 5);
                currentCollision.GetComponent<pushingIsntNice>().health -= 10;
                cooldown = 0.75f;
            }
        }
    }
    public void OnFight2(InputAction.CallbackContext context)
    {
        if (context.performed && currentCollision != null)
        {
            if(cooldown > 0)
            {
                return;
            }
            else if (sr.flipX)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(-5 , 7);
                currentCollision.GetComponent<pushingIsntNice>().health -= 20;
                cooldown = 1.5f;
            }
            else if (!sr.flipX)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(5 , 7);
                currentCollision.GetComponent<pushingIsntNice>().health -= 20;
                cooldown = 1.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetCoolDown(cooldown);
        cooldown -= Time.deltaTime;
        transform.position = player.position;
    }
}
