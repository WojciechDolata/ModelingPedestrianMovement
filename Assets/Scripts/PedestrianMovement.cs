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
                stepTowards(new Vector3(transform.position.x, transform.position.y - 1f));
            else
                stepTowards(new Vector3(transform.position.x, transform.position.y + 1f));
        }
        else
        {
            if (!isOccupied(tryToStepTowards(goal.transform.position)))
                stepTowards(goal.transform.position);
            else
            {
                int upMultiplier = 1;
                if (transform.position.y > goal.transform.position.y)
                    upMultiplier = -1;
                float[] angles = { 30f, 45f, 60f, 90f };
                foreach (float currAngle in angles)
                {
                    Vector3 tmpGoal = getPositionByAngle(upMultiplier * currAngle);
                    if (!isOccupied(tmpGoal))
                    {
                        stepTowards(tmpGoal);
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
        Vector3 vectorFrom00 = tryToStepTowards(goal.transform.position) - transform.position;
        angle += Mathf.Atan(vectorFrom00.y / vectorFrom00.x) * (180 / Mathf.PI); //add angle from vector towards goal
        vectorFrom00 = Quaternion.Euler(0,0,angle) * vectorFrom00;
        return vectorFrom00 + transform.position;
    }
    bool isOccupied(Vector3 point) // checks if point in space is occupied by any collider2d (excluding self)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, collisionRadius);
        if (colliders.Length == 0)
            return false;
        else if (colliders.Length == 1 && colliders[0].transform.position == transform.position)
            return false;
        else
        {
            return true;
        }
    }

    Vector3 tryToStepTowards(Vector3 direction) //used to check if step will result in collision
    {
        return Vector2.MoveTowards(transform.position, direction, 0.5f);
    }
    void stepTowards(Vector3 direction) //to get position for actual step
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, 0.3f*step);
    }
}
