using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehavior : SteerableBehaviour
{
    float angle = 0;

   private void FixedUpdate()
   {
       angle += 0.1f;
       if (angle > 2.0f * Mathf.PI) angle = 0.0f;
       Thrust(0, Mathf.Cos(angle));
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
