using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refraction : MonoBehaviour
{

    public float n2;

    public float thick;


    void Update()
    {
        transform.localScale = new Vector3(thick, transform.localScale.y, transform.localScale.z);
    }
}
