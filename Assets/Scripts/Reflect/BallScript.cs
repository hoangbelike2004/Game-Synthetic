using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5;
    Vector2 last;
    void Start()
    {
        Vector2 mous = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        rb.velocity = mous*speed;
    }
    void TouchWall(Vector2 newvt)
    {
        
    }
    private void Update()
    {
        last = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            var speedlast = last.magnitude;
            Vector2 direction = Vector2.Reflect(last.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speedlast;
        }
    }

}
