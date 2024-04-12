using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int hp;
    private bool isdaed => hp > 0;
    [SerializeField] private GameObject AttackArea;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
    }

    public virtual void OnHit(int damege)
    {
        if (isdaed)
        {
            hp -= damege;
            if (!isdaed)
            {
                OnDeath();
            }
        }
    }
    public virtual void OnDeath()
    {
        OnDestroy();
    }
    public virtual void OnDestroy()
    {
        Destroy(gameObject);
    }
    public virtual void Active()
    {
        AttackArea.SetActive(true);
    }
    public virtual void DeActive()
    {
        AttackArea?.SetActive(false);
    }
}
