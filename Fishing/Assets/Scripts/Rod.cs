using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rod : MonoBehaviour
{
    public GameObject fishHook;
    public LineRenderer rope;
    public Transform startPosition;

    public GameObject warning;
    public Text fishCountText;

    [SerializeField]
    [Range(1,50)]
    private int throwSpeed;

    private Rigidbody hookRB;

    bool isSent;
    bool isTakedBack;

    bool isCatched;
    int fishCount;

    float timer = 0;
    void Start()
    {
        hookRB = fishHook.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fishCountText.text = "Your fish count:" + fishCount.ToString();
        if (isSent)
        {
            CatchFish();
        }
        if (Input.GetKeyDown("k") && isSent != true)
        {
            ThrowHook();
        }
        if (Input.GetKeyDown("m") && isSent == true && isTakedBack == false)
        {
            TakeHookBack();
        }

        rope.positionCount = 2;
        rope.SetPosition(0, startPosition.position);
        rope.SetPosition(1, fishHook.transform.position);
    }
    void ThrowHook()
    {
        isSent = true;
        isTakedBack = false;
        hookRB.constraints = RigidbodyConstraints.None;
        hookRB.AddForce(-Vector3.forward*throwSpeed, ForceMode.Impulse);
    }
    void TakeHookBack()
    {
        isSent = false;
        isTakedBack = true;
        hookRB.constraints = RigidbodyConstraints.FreezeAll;
        fishHook.transform.position = startPosition.position;
        if (isCatched == true)
        {
            fishCount++;
            isCatched = false;
        }
        warning.SetActive(false);
        timer = 0;

    }
    void CatchFish()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            isCatched = true;
            warning.SetActive(true);
        }
        if (timer > 10)
        {
            timer = 0;
            isCatched = false;
            warning.SetActive(false);
        }
    }
}
