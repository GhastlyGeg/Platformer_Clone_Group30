using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 spinDirection = Vector3.zero;
    public float spinSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        //Rotate the object in the set by speed at degrees/second bada bing
        transform.Rotate(spinDirection * spinSpeed * Time.deltaTime);
    }
}
