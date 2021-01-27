using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//플레이어는 Idle, Run, AttackRun, Attack, Dead
//적 Idle, Run, AttackRun, Attack, Dead

public class Enemy : FSM
{
    public float moveSpeed;
    public float rotSpeed;

    CharacterController cc;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        cc = GetComponent<CharacterController>();
    }

}
