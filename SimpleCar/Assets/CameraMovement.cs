using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForStart());
    }
    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(2);
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 2);
    }
}
