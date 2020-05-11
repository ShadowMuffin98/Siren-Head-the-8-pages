using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public Siren_head SH;
    public float Health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(this.transform.position, SH.transform.position);
        if (dis<25)

        {
            Health -= 1;
            if (Health <1)
            {
                SH.show_cam();
            }
        }
        
    }
}
