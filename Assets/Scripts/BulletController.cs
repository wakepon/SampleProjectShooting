using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private float deathY = 11.0f;
    
    void Update()
    {
        transform.position += speed * Vector3.up * Time.deltaTime;
        if (transform.position.y > deathY)
        {
            gameObject.SetActive(false);
        }
    }
}
