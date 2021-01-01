using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public Vector3 offset;
    float yatay = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yatay += 2 * Input.GetAxis("Fire2");
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, 0.1f)+offset;
    }
}
