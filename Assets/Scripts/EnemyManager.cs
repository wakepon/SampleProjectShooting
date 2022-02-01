using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField] private int poolSize = 50;
    [SerializeField] private float birthInterval = 0.5f;
    private List<EnemyController> _enemies = new List<EnemyController>();
    
    private float birthTimer = 0.0f;
    void Start()
    {
        CreatePool();
    }
    
    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.gameObject.SetActive(false);
            _enemies.Add(enemy);
        }
    }
    
    public void Clear()
    {
        foreach (var enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }
        birthTimer = 0.0f;
    }

    void Update()
    {
        birthTimer += Time.deltaTime;
        if (birthTimer > birthInterval)
        {
            Birth();
            birthTimer -= birthInterval;
        }
    }
    
    void Birth()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = GetRandomPos();
    }

    Vector3 GetRandomPos()
    {
        var pos = transform.position;
        const float minX = -5.0f;
        const float maxX = 5.0f;
        float x = Random.Range(minX, maxX);
        pos.x = x;
        return pos;
    }
}
