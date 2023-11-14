using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Harms, Greg & Brown, Dylan
//11/13/2023
//Covers the prospect of a breakable object/wall

public class BreakableObject : MonoBehaviour
{
    public float lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Hitting Wall");
            lives -= 1;
        }

        if (other.gameObject.tag == "Heavy Bullet")
        {
            Debug.Log("Hitting Wall");
            lives -= 1;
        }
    }
}
