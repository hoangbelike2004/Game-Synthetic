using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate
{
    float time;
    float timer;
    public void OnEnter(Enemy enemy)
    {
        time = 0;
        timer = Random.Range(2f, 4f);
        enemy.StopMoving();
    }
    public void OnExcute(Enemy enemy)
    {
        time += Time.deltaTime;
        if(time > timer)
        {
            enemy.ChangeState(new ParTrolState());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
