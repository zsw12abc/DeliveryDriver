using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 250f;
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float slowSpeed = 20f;
    [SerializeField] private float bootSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boost")
        {
            moveSpeed = bootSpeed;
        }
    }
}