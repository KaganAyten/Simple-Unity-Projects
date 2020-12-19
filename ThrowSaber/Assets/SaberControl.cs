using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberControl : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    float rotationSpeed;

    [SerializeField]
    [Range(1, 50)]
    float throwForce;

    public Transform turnPoint;
    public GameObject darthBean;
    public float distance;

    Rigidbody rb;
    float rot = 0;
    float dir = 0;
    bool isThrowed;
    bool turnBack;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, turnPoint.transform.position);
        if (distance >= 20)
        {
            isThrowed = false;
            turnBack = true;
            
        }
        if (isThrowed == false && turnBack == false)
        {
            transform.position = turnPoint.position;
        }
        if (distance <= 1)
        {
            turnBack = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (turnBack)
        {
            TurnBack();
        }
        if (Input.GetButton("Jump"))
        {
            isThrowed = true;
        }
        if (isThrowed)
        {
            Rotation();
            Throw();
        }
    }
    public void TurnBack()
    {
        transform.position = Vector3.Lerp(transform.position, turnPoint.transform.position, Time.deltaTime*2);
        Rotation();
    }
    public void Rotation()
    {
        rot += rotationSpeed * Time.deltaTime*20;
        transform.rotation = Quaternion.Euler(0, rot, 0);
    }
    public void Throw()
    {
        Vector3 vek = new Vector3(turnPoint.position.x, turnPoint.position.y, -(turnPoint.position.z + 20));
        dir += throwForce * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, vek, Time.deltaTime * 2);
    }
}
