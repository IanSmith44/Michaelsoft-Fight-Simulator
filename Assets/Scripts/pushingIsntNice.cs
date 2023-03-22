using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushingIsntNice : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
