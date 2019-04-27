using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 20f;
    public GameObject goal;
    private bool wallCollision = false;
    private float y, x, step, collisionRadius = 0.05f; //do wykrywania czy miejsce jest zajete
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        y = transform.position.y;
        step = speed * Time.deltaTime;
    }

    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        if (wallCollision) // needed so that they wouldn't slow down near wall
        {
            if (transform.position.y > goal.transform.position.y)
                transform.position = stepTowards(new Vector3(transform.position.x, transform.position.y - 1f));
            else
                transform.position = stepTowards(new Vector3(transform.position.x, transform.position.y + 1f));
        }
        else
        {
            if (!isOccupied(tryToStepTowards(goal.transform.position)))
                transform.position = stepTowards(goal.transform.position);
            else
            {
                int up = 1;
                if (transform.position.y > goal.transform.position.y)
                    up = -1;
                float[] arr = { 30f, 45f, 60f, 90f };
                foreach (float a in arr)
                {
                    Vector3 tmpGoal = getPositionByAngle(up * a);
                    if (!isOccupied(tmpGoal))
                    {
                        transform.position = stepTowards(tmpGoal);
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DestroyTrigger")
            Destroy(gameObject);
        else if (collision.collider.tag == "Wall")
            wallCollision = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
            wallCollision = false;
    }

    Vector3 getPositionByAngle(float angle) // rotates vector around pivot (self position)
    {
        Vector3 a = tryToStepTowards(goal.transform.position);
        Vector3 tmp = tryToStepTowards(goal.transform.position) - transform.position;
        float ss = tmp.x, b = tmp.y;
        angle += Mathf.Atan(tmp.y / tmp.x) * (180 / Mathf.PI); //add angle from vector towards goal
        tmp = Quaternion.Euler(0,0,angle) * tmp;
        return tmp + transform.position;
    }
    bool isOccupied(Vector3 point) // checks if point in space is occupied by any collider2d (excluding self)
    {
        Collider2D[] tmp = Physics2D.OverlapCircleAll(point, collisionRadius);
        if (tmp.Length == 0)
            return false;
        else if (tmp.Length == 1 && tmp[0].transform.position == transform.position)
            return false;
        else
        {
            var s = tmp[0].ToString();
            return true;

        }
    }

    Vector3 tryToStepTowards(Vector3 direction) //used to check if step will result in collision
    {
        return Vector2.MoveTowards(transform.position, direction, 0.5f);
    }
    Vector3 stepTowards(Vector3 direction) //to get position for actual step
    {
        return Vector2.MoveTowards(transform.position, direction, 0.3f*step);
    }
}
