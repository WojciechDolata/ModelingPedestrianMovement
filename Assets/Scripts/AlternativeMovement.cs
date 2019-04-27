using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 15;
    private bool onWallCollision = false, onPedestrianCollision = false, wallUpwardsMovement = false, wait = false;
    public GameObject goal;
    private float y, x, step, collisionRadius = 0.01f; //do wykrywania czy miejsce jest zajete
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
        if (!isOccupied(stepTowards(goal.transform.position)))
            transform.position = stepTowards(goal.transform.position);
        else
        {
            Vector3 point1 = getPositionByAngle(45f);
            Vector3 point2 = getPositionByAngle(-45f);
            if (Vector3.Distance(point1, goal.transform.position) < Vector3.Distance(point2, goal.transform.position))
            {
                if (!isOccupied(point1))
                    transform.position = point1;
                else if (!isOccupied(getPositionByAngle(90f)))
                    transform.position = getPositionByAngle(90f);
                // else wait in place
            }
            else
            {
                if (!isOccupied(point2))
                    transform.position = point2;
                else if (!isOccupied(getPositionByAngle(-90f)))
                    transform.position = getPositionByAngle(-90f);
            }
        }
        //function RotatePointAroundPivot(point: Vector3, pivot: Vector3, angles: Vector3): Vector3 {
        //    var dir: Vector3 = point - pivot; // get point direction relative to pivot
        //    dir = Quaternion.Euler(angles) * dir; // rotate it
        //    point = dir + pivot; // calculate rotated point
        //    return point; // return it
        //}
    }

    Vector3 getPositionByAngle(float angle)
    {
        Vector3 tmp = stepTowards(goal.transform.position) - transform.position;
        tmp = Quaternion.Euler(angle, 0, 0) * tmp;
        return tmp + transform.position;
    }
    bool isOccupied(Vector3 point)
    {
        return Physics.CheckSphere(point, collisionRadius);
    }
    Vector3 stepTowards(Vector3 direction)
    {
        return Vector2.MoveTowards(transform.position, direction, step*1.5f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.otherCollider.transform.position.y > this.transform.position.y)
        {
            if (other.gameObject.tag == "Wall")
            {
                onWallCollision = true;
                if (transform.position.y < goal.transform.position.y)
                    wallUpwardsMovement = true;
                else
                    wallUpwardsMovement = false;
            }
            else if (other.gameObject.tag == "Pedestrian")
            {
                onPedestrianCollision = true;
            }
            else if (other.gameObject.tag == "DestroyTrigger")
            {
                Destroy(gameObject);
            }
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onWallCollision = true;

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onWallCollision = false;
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 15;
    private bool onWallCollision = false, onPedestrianCollision = false, wallUpwardsMovement = false, wait = false;
    public GameObject goal;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (onWallCollision)
        {
            if(wallUpwardsMovement)
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y + 10.0f, transform.position.z), speed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 10.0f, transform.position.z), speed * Time.deltaTime);

        }
        else if (onPedestrianCollision)
        {
            //if (transform.position.y < goal.transform.position.y)
            //{
            //    transform.position += transform.up * speed * Time.deltaTime;
            //}

            //else
            //{
            //    transform.position += -transform.up * speed * Time.deltaTime;
            //}
        }
        else
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
        //if (!onPedestrianCollision)
        //{
        //    if (transform.position.x < goal.transform.position.x)
        //    {
        //        transform.position = Vector2.MoveTowards(transform.position, goal.transform.position, speed * Time.deltaTime);
        //    }
        //    else
        //    {
        //        transform.position += transform.right * speed * Time.deltaTime;
        //    }
        //}

        //else
        //{
        //    if (transform.position.y < goal.transform.position.y)
        //    {
        //        transform.position += transform.up * speed * Time.deltaTime;
        //    }

        //    else
        //    {
        //        transform.position += -transform.up * speed * Time.deltaTime;
        //    }
        //}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.otherCollider.transform.position.y > this.transform.position.y)
        {
            if (other.gameObject.tag == "Wall")
            {
                onWallCollision = true;
                if (transform.position.y < goal.transform.position.y)
                    wallUpwardsMovement = true;
                else
                    wallUpwardsMovement = false;
            }
            else if (other.gameObject.tag == "Pedestrian")
            {
                onPedestrianCollision = true;
            }
            else if (other.gameObject.tag == "DestroyTrigger")
            {
                Destroy(gameObject);
            }
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onWallCollision = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            onWallCollision = false;
        }
    }
}
*/