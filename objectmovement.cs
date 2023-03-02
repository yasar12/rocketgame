using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmovement : MonoBehaviour
{
    Vector3 startposition;
   [SerializeField] Vector3 movementVector;
   [SerializeField] [Range(0,1)] float  movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startposition= transform.position;
        Debug.Log(startposition);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (period <=Mathf.Epsilon) { return; }
        const float tau = MathF.PI * 2;
        float periodd=Time.time/period ;
        float rawsin = MathF.Sin(periodd*tau);
       movementFactor=rawsin;

        Vector3 offset = movementVector * movementFactor;
        transform.position= startposition + offset;
    }
}
