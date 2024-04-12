using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : Istate
{
    float time, timer;
    public void OnEnter(Enemy enemy)
    {
        time = 2f; timer = 2f;
    }
    public void OnExcute(Enemy enemy)
    {
        time += Time.deltaTime;
        if(time >= timer)
        {
            enemy.Attack();
            time = 0;
        }
        else if(time < timer)
        {
           enemy.ChangeState(new IdleState());
        }
        if (!enemy.EnemyAttack())
        {
            enemy.ChangeState(new IdleState());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
