using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public float angle;

    public Material material;
    LaserBeam beam;

    void Start()
    {
        //transform.eulerAngles = new Vector3(0, 0, angle);
        
    }

    void Update()
    {
        if (beam != null)
            Destroy(beam.laserObj);
        if(Time.timeScale!=0)
        {
            beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
        }
        //beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}
