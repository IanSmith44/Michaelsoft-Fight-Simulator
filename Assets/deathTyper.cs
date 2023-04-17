using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class deathTyper : MonoBehaviour
{
    [SerializeField] private GameObject Y;
    [SerializeField] private GameObject o;
    [SerializeField] private GameObject u;
    [SerializeField] private GameObject S;
    [SerializeField] private GameObject u;
    [SerializeField] private GameObject c;
    [SerializeField] private GameObject k;
    [SerializeField] private GameObject !;
    private float timer = 0;
    private bool timing = false;
    public void onDie(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            timing = true;
            timer = 1.6f
        }
    }
    void Update()
    {
        if(!timing)
        {
            timer -= Time.DeltaTime;
            if(timer <= 1.6)
            {
                
            }
        }
    }
}
