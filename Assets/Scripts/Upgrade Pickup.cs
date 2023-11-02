using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickup : MonoBehaviour
{
    public Vector3 spinDirection = Vector3.zero;
    public float spinSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the object in the set by speed at degrees/second bada bing
        transform.Rotate(spinDirection * spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("if statement works lol");
            Destroy(this.gameObject);
        }
    }
}
