﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int amountOfBalls = 3;
    // Start is called before the first frame update

    [HideInInspector] public bool isOnGame = false;

    [HideInInspector] public int points = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 7){
            isOnGame = true;
        }
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            if(amountOfBalls > 0){
                amountOfBalls--;
            }

            if(amountOfBalls != 0){
                transform.position = new Vector3(14f, 1.1f, -12f);
                isOnGame = false;
            }
        }

    }

     void OnCollisionEnter (Collision other) 
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            points += 1;
        }
        if (other.gameObject.CompareTag("30Points"))
        {
        points += 30;
        }
        if (other.gameObject.CompareTag("20Points"))
        {
        points += 20;
        }
        if (other.gameObject.CompareTag("10Points"))
        {
            points += 10;
        }
        if (other.gameObject.CompareTag("2Points"))
        {
            points += 2;
        }
    }
}
