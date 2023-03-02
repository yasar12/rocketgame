using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotionspeed = 300.88f;
    Rigidbody rb;
    AudioSource aus;
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem boostmain;
    [SerializeField] ParticleSystem boostleft;
     [SerializeField] ParticleSystem boostright;
    // Start is called before the first frame update
    void Start()
    {
      rb=  GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        thrust();
    }
  
    void Rotation()
    {
        if (Input.GetKey(KeyCode.A))

        {
           
            NewMethod(+1);
            if (!boostright.isPlaying) { 
            boostright.Play();
            boostleft.Stop();
            
            }
            
        }
       
        else  if (Input.GetKey(KeyCode.D))

        {
            
           NewMethod(-1);
            if (!boostleft.isPlaying)
            {
                boostleft.Play();
                boostright.Stop();

            }
        }
    }

    public void NewMethod(float rotiondirection)
    {
        rb.freezeRotation = true; //rotasyonu durdurur
        transform.Rotate(Vector3.forward * rotionspeed * Time.deltaTime *rotiondirection);
        rb.freezeRotation = false;
    }

    void thrust()
    {
        if (Input.GetKey(KeyCode.Space))

        {
            boostmain.Play();
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!aus.isPlaying)
            {
                aus.PlayOneShot(mainengine);
            }


        }
        else {
            aus.Stop();
            boostright.Stop();
        }

    }
}
