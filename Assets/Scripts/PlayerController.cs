using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Harms, Greg
//10/26/2023
//Handles all player movement and collision detection for player object

public class NewBehaviourScript : MonoBehaviour
{   
    public float speed = 10f;

    public float deathYLevel = -3f;

    public float jumpForce = 20f;

    public float lives;

    private Rigidbody rigidBodyRef;

    private Vector3 startPos;

    public GameObject bulletPrefab;

    public GameObject heavyBulletPrefab;

    public bool shootRight;

    public bool facingRight;

    public bool heavyBullet;
    public bool bullet = true;

    public bool jumpPack;

    public bool healthBooster;

    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody component off of this object and stores a reference to it
        rigidBodyRef = GetComponent<Rigidbody>();

        //set the starting position
        lives = 99;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            shootRight = true;
        }
        else
        {
            shootRight = false;
        }

        //going left
        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight == true)
            {
                //make player rotate when key pressed
                //use bools to switch facingRight on and off
                facingRight = false;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //going right
        else if (Input.GetKey(KeyCode.D))
        {
            if(facingRight == false)
            {
                facingRight = true;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }

        if (transform.position.y <= deathYLevel)
        {
            Respawn();
        }

        if(Input.GetKey(KeyCode.E) && heavyBullet == false && bullet == true)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletInstance.GetComponent<Bullet>().goingRight = shootRight;
        }

        if (heavyBullet == true && bullet == false)
        {
            
            GameObject bulletinstance = Instantiate(heavyBulletPrefab, transform.position, transform.rotation);
            bulletinstance.GetComponent<HeavyBullet>().goingRight = shootRight;
        }

        CheckForDamage();
    }

    private void Respawn()
    {
        //teleport the player to the starting position
        //cause the player to lose a life
        transform.position = startPos;

        if (lives == 0)
        {
            //add code to end the game, by loading the game over scene
            SceneManager.LoadScene(1);
            Debug.Log("Game Ends");
        }
    }

    private void CheckForDamage()
    {
        RaycastHit hit;
        //Raycast upwards and check the raycast will return true if it hits an object
        //Raycast(startPos, direction, output hit, distance for ray
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1))
        {
            //check to see if the object hitting the player is tagged thwomp
            if (hit.collider.tag == "Thwomp")
            {
                Respawn();
            }
        }
    }

    private void HandleJump()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            //Debug.Log("Player is touching the ground so jump");
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            //Debug.Log("Player is not touching the ground so they can't jump");
        }
    }

    /// <summary>
    /// collects any coins
    /// </summary>
    /// <param name="other">The object being collided with</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            lives -= 15;
            Respawn();
        }

        if (other.gameObject.tag == "Heavy enemy")
        {
            lives -= 30;
            Respawn();
        }

        if (other.gameObject.tag == "Heavy Bullet Pickup")
        {
            bullet = false;
            heavyBullet = true;
            Debug.Log("Player picked up heavy bullet upgrade");
        }
    }
}
