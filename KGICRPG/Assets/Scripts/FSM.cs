using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public enum State
    {
        Idle = 0,
        Run = 1,
        Attack = 2,
        Dead = 3,
        AttackRun = 4,
    }

    protected State currentState = State.Idle;
    protected Animator animator;

    protected bool isNewState = false;

    //virtual override


    private void OnEnable()
    {
        StartCoroutine(FSMUpdate());
    }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();

        SetState(State.Idle);
    }

    public void SetState(State newState)
    {
        isNewState = true;
        currentState = newState;
        //GetComponent<Animator>().SetInteger("state", (int)newState);
        animator.SetInteger("state", (int)newState);
    }

    IEnumerator FSMUpdate()
    {
        while(true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    protected virtual IEnumerator Idle()
    {
        yield return null;
    }

    protected virtual IEnumerator Run()
    {
        yield return null;
    }

}
