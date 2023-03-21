using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightCollider : MonoBehaviour
{
    [SerializeField] private fight fightscript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            fightscript.currentCollision = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            fightscript.currentCollision = null;
        }
    }
}
