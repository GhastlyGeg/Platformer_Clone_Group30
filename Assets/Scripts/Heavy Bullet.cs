using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : MonoBehaviour
{
    public float speed;
    public bool goingRight;

    private void Start()
    {
        StartCoroutine(DespawnDelay());
    }

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
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
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
