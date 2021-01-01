using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        float ver = Input.GetAxis("Vertical");
        transform.Translate(-hor * Time.deltaTime * 5, 0, -ver*Time.deltaTime*5);
        
    }
}
