using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTyper : MonoBehaviour
{
    [SerializeField] private GameObject Y;
    [SerializeField] private GameObject o;
    [SerializeField] private GameObject u1;
    [SerializeField] private GameObject S;
    [SerializeField] private GameObject u2;
    [SerializeField] private GameObject c;
    [SerializeField] private GameObject k;
    [SerializeField] private GameObject ex;
    [SerializeField] private GameObject die;
    [SerializeField] private float timb = 0.2f;
    private float time;
    private float timer = 0;
    [SerializeField] private bool timing = false;
    public void onDie()
    {
        time = timb * 8;
        timing = true;
        timer = time;
        die.SetActive(true);
    }
    void Update()
    {
        if(timing)
        {
            timer -= Time.deltaTime;
            if(timer <= time - timb)
            {
                Y.SetActive(true);
            }
            if(timer <= time - (timb*2))
            {
                o.SetActive(true);
            }
            if(timer <= time - (timb*3))
            {
                u1.SetActive(true);
            }
            if(timer <= time - (timb*4))
            {
                S.SetActive(true);
            }
            if(timer <= time - (timb*5))
            {
                u2.SetActive(true);
            }
            if(timer <= time - (timb*6))
            {
                c.SetActive(true);
            }
            if(timer <= time - (timb*7))
            {
                k.SetActive(true);
            }
            if(timer <= time - (timb*8))
            {
                ex.SetActive(true);
            }
            if(timer <= time - (timb*12))
            {

            }
        }
    }
}
