using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : MonoBehaviour
{
    public float speed;
    public bool goingRight;

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
}
