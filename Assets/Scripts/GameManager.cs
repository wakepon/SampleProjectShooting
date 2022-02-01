using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text failedText;
    [SerializeField] private PlayerController playerController;

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
    
    void Update()
    {
        switch (_state)
        {
            case State.ready:
                failedText.gameObject.SetActive(false);
                playerController.ReadyToStart();
                score = 0;
                scoreText.text = score.ToString();
                ChangeState(State.run);
                break;
            case State.run:
                scoreText.text = score.ToString();
                // if (playerController.transform.position.y < DeadY)
                // {
                //     ChangeState(State.result);
                //     playerController.Stop();
                // }
                break;
            case State.result:
                failedText.gameObject.SetActive(true);
                if (_stateTimer > 2.0f)
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