﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float friction;

    private float speed = 0;
    private bool flipped = false;
    private bool floored = false;
    private bool moving = false;
    private bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vel = new Vector3(0.1f, 0.1f, 0f);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 0f);

        // Smoothened input float
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        bool right = horizontal > 0 ? true : false;
        bool left = horizontal < 0 ? true : false;
        if(left || right)
        {
            moving = true;
        } else
        {
            moving = false;
        }
        bool space = Input.GetKeyDown(KeyCode.Space);
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        speed += horizontal * Time.deltaTime * acceleration;

        float adjustedSpeed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        if (!moving)
        {
            adjustedSpeed = 0;
        }
        speed = adjustedSpeed;

        if (left && !flipped)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            flipped = true;
        }

        if (right && flipped)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            flipped = false;
        }

        if (floored && space)
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, jumpVelocity);
            floored = false;
        }

        gameObject.GetComponent<Transform>().position += new Vector3(adjustedSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collission)
    {
        Debug.Log("Floored");
        if (!floored)
        {
            floored = true;
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }
    }
}
