using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool move;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            move = true;
            
        }
        if (move)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(camRay, out hitInfo, 1000))
            {
                transform.position = Vector3.Lerp(transform.position, hitInfo.point, Time.deltaTime * 3);
            }
            float distance = Vector3.Distance(transform.position, hitInfo.point);
            if (distance <= 1)
            {
                move = false;
            }
        }

    }
}
