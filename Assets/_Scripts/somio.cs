// https://youtu.be/esnaEYYD1ZM codigo estraido deste tutorial
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,0.5f);
        transform.localPosition += new Vector3(0,0.5f,0);
    }

}
