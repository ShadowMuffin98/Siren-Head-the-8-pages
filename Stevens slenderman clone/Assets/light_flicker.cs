using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_flicker : MonoBehaviour
{
    public Light light;
    public float lightlow = 3;
    public float lighthigh = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = Random.Range(lightlow, lighthigh);
    }
}
