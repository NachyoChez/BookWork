﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
   private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool startGame;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        startGame = false;

        //print(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {

        if (!startGame)
        {
            //lock ball to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //launches pall and starts game on mouse press
            if (Input.GetMouseButtonDown(0))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                startGame = true;
            }//end if mouse
        }//end if startGame
    }//end update

    void OnCollisionEnter2D(Collision2D col)
    {
        if (startGame)
        {
            Vector3 tweak = new Vector3(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f), 0f);
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody>().velocity += tweak;
        }

    }
}//end Ball class
