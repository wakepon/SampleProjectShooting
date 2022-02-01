using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }

    public void ReadyToStart()
    {
        transform.position = startPosition;
    }

    public void Stop()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += moveSpeed * Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveSpeed * Vector3.right * Time.deltaTime;
        }
    }
}