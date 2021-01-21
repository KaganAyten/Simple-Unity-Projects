using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingRod : MonoBehaviour
{
    public GameObject fishHook;
    public LineRenderer rope;
    public Transform startPos;
    private Rigidbody hookRB;

    public GameObject warning;

    public Text fishCountText;

    public bool isSent;
    public bool isTakedBack;

    public bool isCatched;

    public int fishCount;
    float number =0;

    [SerializeField]
    [Range(1, 50)]
    int throwSpeed;
    void Start()
    {
        hookRB = fishHook.GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        fishCountText.text = "Your fish count is: " + fishCount.ToString();
        rope.positionCount = 2;
        rope.SetPosition(0, startPos.position);
        rope.SetPosition(1, fishHook.transform.position);


        if (isSent)
        {
            CatchFish();
        }
        if (Input.GetKeyDown("k")&& isSent !=true)
        {
            SendHook();
        }
        if (Input.GetKeyDown("m") && isSent == true && isTakedBack == false)
        {
            TakeHookBack();
        }

    }
    void SendHook()
    {
        isTakedBack = false;
        isSent = true;
        hookRB.constraints = RigidbodyConstraints.None;
        hookRB.AddForce(-Vector3.forward * throwSpeed, ForceMode.Impulse);
        
    }
    void TakeHookBack()
    {
        isSent = false;
        isTakedBack = true;
        hookRB.constraints = RigidbodyConstraints.FreezeAll;
        fishHook.transform.position = startPos.position;
        if (isCatched == true)
        {
            fishCount++;
            isCatched = false;
           
        }
        warning.SetActive(false);
        number = 0;
    }
    void CatchFish()
    {
        
        number += Time.deltaTime;
        if (number >= 5)
        {
            isCatched = true;
            warning.SetActive(true);
        }
       if (number > 10)
        {
            number = 0;
            warning.SetActive(false);
            isCatched = false;
        }

    }
}
