using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    
    // Update is called once per frame
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] Animator anim;
    private Istate Current;
    [SerializeField] private List<GameObject> wallPoint;
    bool iswall;
    [SerializeField] Transform PlayerPos;
    [SerializeField] float attackRange=1.2f;
    [SerializeField] LayerMask Pla;

    public Character taget;
    RaycastHit2D ray;
    void Update()
    {
       
        Debug.DrawLine(transform.position, transform.position + Vector3.right*4f, Color.red);
        Debug.DrawLine(transform.position, transform.position + Vector3.left * 4f, Color.red);
        EnemyAttack();
        Wall();
        if (Current != null)
        {
            Current.OnExcute(this);
        }
        

        //MoveToPlayer();

    }
    public void ChangeState(Istate newIstate)
    {
        if (Current != null)
        {
            Current.OnExit(this);
        }
        Current = newIstate;
        if (Current != null)
        {
            
            Current.OnEnter(this);
        }
        

    }
    public void Moving()
    {
        if(!Isleft()&&!Isright())
        {
          Debug.Log("Move");
            transform.rotation = Quaternion.Euler(0, iswall ? 180 : 0, 0);
            rb.velocity = transform.right * moveSpeed;
            anim.SetInteger("State", 1);
        }
          
        else if (Isleft())
        {
            Debug.Log("left");
            MoveToPlayer();
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Isright())
        {
            Debug.Log("right");
            MoveToPlayer();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
        anim.SetInteger("State", 0);
    }
    public void Attack()
    {
        
        anim.SetInteger("State", 2);
        
    }
    public override void OnDeath()
    {
        base.OnDeath();
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
    }
    public void Wall()
    {
        if (Vector2.Distance(wallPoint[0].transform.position,transform.position)< 0.1f)
        {
            iswall = false;
        }
        if (Vector2.Distance(wallPoint[1].transform.position, transform.position) < 0.1f)
        {
            iswall = true;
        }
    }
    public bool EnemyAttack()
    {
        if (Vector2.Distance(transform.position, PlayerPos.position) <= attackRange)
        {
            return true;
            
        }
        else return false;
    }
    public void MoveToPlayer()
    {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = PlayerPos.position;

        Vector3 directionPla = playerPos - enemyPos;

        rb.velocity = directionPla * (moveSpeed-1.5f);
        anim.SetInteger("State", 1);
    }

    public bool Isleft()
    {
        if (Physics2D.Raycast(transform.position, Vector3.left , 4f, Pla)){
            return true;
        }
        else return false;
        
    }
    public bool Isright()
    {
        if (Physics2D.Raycast(transform.position, Vector3.right , 4f, Pla)){
            return true;
        }
        else return false;
    }


}
