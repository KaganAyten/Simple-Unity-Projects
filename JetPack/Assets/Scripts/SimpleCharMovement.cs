using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float horMovement = 0;

    float verMovement = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        
        horMovement += hor * Time.deltaTime * 5;
        verMovement += ver * Time.deltaTime * 5;
        transform.position = new Vector3(-horMovement, transform.position.y, -verMovement);
        
    }
}
