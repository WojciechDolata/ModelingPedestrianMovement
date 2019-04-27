using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 15;
    private bool onCollision = false;
    public GameObject goal;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!onCollision)
        {
            if (transform.position.x < goal.transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, goal.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
        }

        else
        {
            if (transform.position.y < goal.transform.position.y)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }

            else
            {
                transform.position += -transform.up * speed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onCollision = true;
        }

        else if (other.gameObject.tag == "DestroyTrigger")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onCollision = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onCollision = false;
        }
    }
}
