using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float deathY = -11.0f;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        _rigidbody2D.velocity = Vector3.zero;
    }

    void Update()
    {
        if (transform.position.y < deathY)
        {
            gameObject.SetActive(false);
        }
    }
}
