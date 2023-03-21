using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class fight : MonoBehaviour
{
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
            if (sr.flipX)
            {
                currentCollision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100 , 100));
            }
            else if (!sr.flipX)
            {
                currentCollision.GetComponent<Rigidbody2D>().AddForce(new Vector2(100 , 100));
            }
        }
    }
    public void OnFight2(InputAction.CallbackContext context)
    {
        if (context.performed && currentCollision != null)
        {
            Debug.Log("Fight2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
