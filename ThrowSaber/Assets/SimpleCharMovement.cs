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
        float mov=0;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(hor * Time.deltaTime * 5, 0, 0);
    }
}
