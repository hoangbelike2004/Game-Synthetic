using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : Character
{
    // Start is called before the first frame update
    Animator anim;
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float height;
    BoxCollider2D box;
    [SerializeField] private LayerMask Plf;
    [SerializeField] private float HorX;
    private bool isAttack,isPland;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        isPland = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeAnim();

        if (IsGround()&& Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            
        }
    }

    private void Move()
    {
        HorX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(HorX*speed,rb.velocity.y);
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up*height, ForceMode2D.Impulse);
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, Plf);
    }
    private void Attack()
    {
      isAttack = true;
    }
    private void ChangeAnim()
    {
        
        if (IsGround() && Mathf.Abs(HorX) == 0 && Mathf.Abs(rb.velocity.y) == 0)
        {
            anim.SetInteger("State", 0);
        }
        if (rb.velocity.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (IsGround())
            {
                anim.SetInteger("State", 1);
            }
        }
        else if (rb.velocity.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (IsGround())
            {
                anim.SetInteger("State", 1);
            }
        } 

        if (rb.velocity.y > .1f)
        {
            anim.SetInteger("State", 3);
            //State = StateAnim.Jump;
            isPland = true;
        }
        else if(rb.velocity.y < 0)
        {
            //State = StateAnim.Fall;
            anim.SetInteger("State", 4);
            
        }
        else if (isPland&&IsGround())
        {
            anim.SetInteger("State", 5);
            isPland = false;
        }

        if (Input.GetKeyDown(KeyCode.J)&&IsGround() && Mathf.Abs(HorX) == 0)
        {
            anim.SetInteger("State", 2);
        }

    }
}
