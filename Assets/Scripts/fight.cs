using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fight : MonoBehaviour
{
    public bool coolingdown = false;
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
            if(cooldown >= 3f)
            {
                coolingdown = true;
                return;
            }
            else if (sr.flipX && cooldown <= 2.5f && !coolingdown)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(-5 , 5);
                currentCollision.GetComponent<pushingIsntNice>().health -= 10;
                cooldown += 0.75f;
                if(cooldown >= 3f)
                {
                    coolingdown = true;
                }
            }
            else if (!sr.flipX && cooldown <= 2.5f && !coolingdown)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(5 , 5);
                currentCollision.GetComponent<pushingIsntNice>().health -= 10;
                cooldown += 0.75f;
                if(cooldown >= 3f)
                {
                    coolingdown = true;
                }
            }
        }
    }
    public void OnFight2(InputAction.CallbackContext context)
    {
        if (context.performed && currentCollision != null)
        {
            if(cooldown <= 0f)
            {
                cooldown = 0f;
                coolingdown = false;
            }
            if(cooldown >= 3f)
            {
                return;
            }
            else if (sr.flipX && cooldown <= 2.25f && !coolingdown)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(-5 , 7);
                currentCollision.GetComponent<pushingIsntNice>().health -= 20;
                cooldown += 1.5f;
                if(cooldown >= 3f)
                {
                    coolingdown = true;
                }
            }
            else if (!sr.flipX && cooldown <= 2.25f && !coolingdown)
            {
                currentCollision.GetComponent<Rigidbody2D>().velocity = new Vector2(5 , 7);
                currentCollision.GetComponent<pushingIsntNice>().health -= 20;
                cooldown += 1.5f;
                if(cooldown >= 3f)
                {
                    coolingdown = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown >= 3f)
        {
            coolingdown = true;
        }
        if(cooldown <= 0f)
        {
            cooldown = 0f;
            coolingdown = false;
        }
        healthBar.SetCoolDown(cooldown);
        cooldown -= Time.deltaTime;
        transform.position = player.position;
    }
}
