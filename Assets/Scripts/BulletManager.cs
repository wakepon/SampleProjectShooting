using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private int poolSize = 50;
    [SerializeField] private float shootingInterval = 0.3f;
    private List<BulletController> _bullets = new List<BulletController>();

    private float shootTimer = 0.0f;
    
    void Start()
    {
        CreatePool();
    }

    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }
    }

    public void Clear()
    {
        foreach (var bullet in _bullets)
        {
            bullet.gameObject.SetActive(false);
        }
        shootTimer = 0.0f;
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootingInterval)
        {
            Shoot();
            shootTimer -= shootingInterval;
        }
    }

    void Shoot()
    {
        foreach (var bullet in _bullets)
        {
            if (!bullet.gameObject.activeSelf)
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = transform.position;
                return;
            }
        }
    }
}
