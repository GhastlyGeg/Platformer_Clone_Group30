using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
