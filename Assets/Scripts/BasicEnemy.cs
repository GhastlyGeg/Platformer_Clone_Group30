using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float travelDistanceRight = 0;
    public float travelDistanceLeft = 0;
    public float speed;
    public float lives;

    private float startingX;
    private bool movingRight = true;

    public bool littleGuy;
    public bool bigGuy;

    // Start is called before the first frame update
    void Start()
    {
        //when the scene starts store the initial x value of this object
        startingX = transform.position.x;

        if (littleGuy == true)
        {
            lives = 3;
        }

        if (bigGuy == true)
        {
            lives = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            //if the object is not farther than the start position + right travel dist, it can move right
            if (transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            //is the object is not farther than the start position + ledt travel distance, it can move left
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            //if the object goes too far left, tell it to move right
            else
            {
                movingRight = true;
            }
        }

        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (littleGuy == true)
        {
            if (other.gameObject.tag == "Bullet")
            {
                lives -= 1;
            }

            if (other.gameObject.tag == "Heavy Bullet")
            {
                lives -= 3;
            }
        }

        if (bigGuy == true)
        {
            if (other.gameObject.tag == "Bullet")
            {
                lives -= 1;
            }

            if (other.gameObject.tag == "Heavy Bullet")
            {
                lives -= 4;
            }
        }
    }
}
