using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Harms, Greg & Brown, Dylan
//11/13/2023
//Handles bullet movement and behavior

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool goingRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("colliding");

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Heavy Enemy")
        {
            Destroy(this.gameObject);

        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}