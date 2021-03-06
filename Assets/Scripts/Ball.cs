﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    Vector3 paddleToBall;
    bool gameStarted=false;
    [SerializeField] float xPush=2f;
    [SerializeField] float yPush=15f;
    [SerializeField] AudioClip[] ballSounds;

    // cached component reference
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            transform.position = paddle1.transform.position + paddleToBall; //stick ball to the paddle
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            gameStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length - 1)];
            audioSource.PlayOneShot(clip);
        }
    }
}
