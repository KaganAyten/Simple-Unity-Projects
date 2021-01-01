using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 grapPoint;
    public Transform startPos;
    private SpringJoint joint;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartHooking();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopHooking();
        }
    }
    private void LateUpdate()
    {
        DrawLine();
    }
    void StartHooking()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(camRay,out hit, 1000))
        {
            grapPoint = hit.point;
            joint = gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapPoint;

            line.positionCount = 2;
        }
    }
    void StopHooking()
    {
        line.positionCount = 0;
        Destroy(joint);
    }
    void DrawLine()
    {
        if (!joint) return;

        line.SetPosition(0, startPos.position);
        line.SetPosition(1, grapPoint);
    }
}
