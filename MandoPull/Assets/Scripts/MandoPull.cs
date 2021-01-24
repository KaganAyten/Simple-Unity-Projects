using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandoPull : MonoBehaviour
{
    private LineRenderer line;
    public Transform bringPosition;
    GameObject pulledChar;
    bool pulling;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        pulling = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (pulling)
        {
            line.positionCount = 2;
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, pulledChar.transform.position);

            float distance = Vector3.Distance(pulledChar.transform.position, bringPosition.position);
            pulledChar.transform.position = Vector3.Lerp(pulledChar.transform.position, bringPosition.position, Time.deltaTime*2);
            if (distance < 0.20f)
            {
                pulling = false;
                line.positionCount = 0;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            BringIt();
        }
    }
    void BringIt()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 1000))
        {
            if (hit.collider.tag == "pullable")
            {
                pulledChar = hit.collider.gameObject;
                pulling = true;
            }
        }
    }
}
