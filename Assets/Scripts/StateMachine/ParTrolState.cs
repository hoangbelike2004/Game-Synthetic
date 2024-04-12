using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParTrolState : Istate
{
    float time, timer;
    public void OnEnter(Enemy enemy)
    {
        time = 0;
        timer = Random.Range(3f,6f);
        
    }
    public void OnExcute(Enemy enemy)
    {
    time += Time.deltaTime;
        if (time < timer)
        {
            enemy.Moving();

        }
        else
        {
            enemy.ChangeState(new IdleState());
        }

        if (enemy.EnemyAttack())
        {
            Debug.Log("Attack");
            enemy.ChangeState(new AttackState());
        }

    }
    public void OnExit(Enemy enemy) { 
    
    }
}
