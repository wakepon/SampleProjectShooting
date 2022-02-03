using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text failedText;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EnemyManager enemyManager;

    enum State
    {
        ready,
        run,
        result
    }

    private State _state = State.ready;
    private float _stateTimer = 0.0f;
    private const float DeadY = -10.0f;
    private int score = 0;

    private void Start()
    {
        ChangeState(State.ready);
        enemyManager.OnHit.AddListener(() => { score++; });
        playerController.OnDie.AddListener(() => { ChangeState(State.result); });
    }

    void Update()
    {
        switch (_state)
        {
            case State.ready:
                failedText.gameObject.SetActive(false);
                enemyManager.Clear();
                enemyManager.gameObject.SetActive(true);
                playerController.ReadyToStart();
                score = 0;
                scoreText.text = score.ToString();
                ChangeState(State.run);
                break;
            case State.run:
                scoreText.text = score.ToString();
                break;
            case State.result:
                failedText.gameObject.SetActive(true);
                enemyManager.gameObject.SetActive(false);
                if (_stateTimer > 1.0f && Input.anyKeyDown)
                {
                    ChangeState(State.ready);
                }

                break;
        }

        _stateTimer += Time.deltaTime;
    }

    void ChangeState(State nextState)
    {
        _state = nextState;
        _stateTimer = 0.0f;
    }
}