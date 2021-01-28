using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bombObject;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camRay, out hit, 1000))
            {
                GameObject temp = Instantiate(bombObject);
                temp.GetComponent<Bomb>().SetDestination(hit.point);
            }
        }
        
    }
}
