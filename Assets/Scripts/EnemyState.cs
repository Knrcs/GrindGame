using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public State currentState = State.Idle;
    
    private void Update()
    {
        //Goes through the states and executes functions in current State
        switch (currentState)
        {
            case State.Idle:
                Debug.Log("Idle gamer");
                break;
            case State.Attack:
                Debug.Log("Grrrr I'm mad at youu");
                break;
            case State.Retreat:
                Debug.Log("Goodbye Gamer!");
                break;
        }
    }
}

[Serializable]
public enum State { Idle, Attack, Retreat}