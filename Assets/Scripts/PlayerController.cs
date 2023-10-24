using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Harms, Greg
//10/23/2023
//Handles movement and collision for the player

public class NewBehaviourScript : MonoBehaviour
{
    public int totalCoins = 0;
    
    public float speed = 10f;

    public float deathYLevel = -3f;

    public float jumpForce = 10f;

    public float lives;

    private Rigidbody rigidBodyRef;
    private Vector3 startPos;
    private bool stunned = false;

    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody component off of this object and stores a reference to it
        rigidBodyRef = GetComponent<Rigidbody>();

        //set the starting position
        lives = 3;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //going left
        if (Input.GetKey(KeyCode.A) && stunned == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        //going right
        if (Input.GetKey(KeyCode.D) && stunned == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && stunned == false)
        {
            HandleJump();
        }

        if (transform.position.y <= deathYLevel)
        {
            Respawn();
        }

        CheckForDamage();
    }

    private void Respawn()
    {
        //teleport the player to the starting position
        //cause the player to lose a life
        lives--;
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
        if (other.gameObject.tag == "Coin")
        {
            totalCoins++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Respawn();
        }

        if (other.gameObject.tag == "Portal")
        {
            Debug.Log("Interacted with portal");
            //move the player to the teleport point's position stored on the Portal object
            transform.position = other.gameObject.GetComponent<Portal>().teleportPoint.transform.position;
            startPos = transform.position;
        }

        if (other.gameObject.tag == "Laser")
        {
            StartCoroutine(StunPlayer());
        }

        if (other.gameObject.tag == "Tar")
        {
            Respawn();
        }

        if (other.gameObject.tag == "Bullet")
        {
            Respawn();
        }
    }

    IEnumerator StunPlayer()
    {
        stunned = true;
        yield return new WaitForSeconds(2);
        stunned = false;
    }
}
