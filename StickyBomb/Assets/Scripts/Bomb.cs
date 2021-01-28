using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Vector3 target;
    public ParticleSystem explodeParticle;
    public void SetDestination(Vector3 target)
    {
        this.target = target;
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 5);
        if (Input.GetKeyDown("g"))
        {
            StartCoroutine(MakeExplode());
        }
    }
    IEnumerator MakeExplode()
    {
        explodeParticle.Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
