using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowb : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GameObject player;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.name);
        transform.position = enemy.transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            player.GetComponent<PlayerController>().dying = true;
            if(player.GetComponent<PlayerController>().currentHealth <= 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 10f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(player != null)
        {
            if (other.gameObject.tag == "Player")
            {
                player.GetComponent<PlayerController>().dying = false;
                player = null;
            }
        }
    }
}
