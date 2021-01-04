using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int jetPackForce = 2;
    [SerializeField] private float jetPackFuel = 10;
    private bool isUsing;
    [SerializeField] private GameObject ParticleLeft, ParticleRight;
    [SerializeField] private Image UIBar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jetPackFuel >= 10)
        {
            jetPackFuel = 10;
        }
        UIBar.fillAmount = jetPackFuel / 10;
        if (Input.GetButton("Fire1"))
        {
            if (jetPackFuel > 0)
            {
                StartJetPack();
            }
        }
        else
        {
            StopJetPack();
        }
        if(jetPackFuel<=0&&isUsing==false)
        {
            StopJetPack();
        }
    }
    void StartJetPack()
    {
        rb.AddForce(Vector3.up * jetPackForce);
        jetPackFuel -= Time.deltaTime;
        isUsing = true;
        ParticleLeft.GetComponent<ParticleSystem>().Play();
        ParticleRight.GetComponent<ParticleSystem>().Play();
    }
    void StopJetPack()
    {
        jetPackFuel += Time.deltaTime;
        isUsing = false;
        ParticleLeft.GetComponent<ParticleSystem>().Stop();
        ParticleRight.GetComponent<ParticleSystem>().Stop();
    }
}
