using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidDash : MonoBehaviour
{
    public Transform self;
    public Rigidbody rb;
    public float speed;
    public ParticleSystem P;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        self = GetComponent<Transform>();
        P = transform.GetChild(0).GetComponent<ParticleSystem>();
        StartCoroutine(dash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dash()
    {
        yield return new WaitForSeconds(.3f);
        rb.velocity = self.forward * speed;
        P.Play();
        yield return new WaitForSeconds(.3f);
        rb.velocity = Vector3.zero;
        P.Stop();
        yield return new WaitForSeconds(.3f);
        rb.velocity = self.forward * speed;
        P.Play();
        yield return new WaitForSeconds(.3f);
        rb.velocity = Vector3.zero;
        P.Stop();
        yield return new WaitForSeconds(.3f);
        rb.velocity = self.forward * speed;
        P.Play();
        yield return new WaitForSeconds(.3f);
        rb.velocity = Vector3.zero;
        P.Stop();
    }
}
