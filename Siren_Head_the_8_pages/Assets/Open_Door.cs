using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public float Close = 0;
    public float Open = 122.168f;
    public GameObject openpoint;
    bool isOpen = false;
    void Update()
    {
        if (Input.GetButtonDown("interact"))
        {
            GameObject p = GameObject.Find("Player");
            float dis = Vector3.Distance(openpoint.transform.position, p.transform.position);
            if (dis <2.5 )
            {
            isOpen = !isOpen;
            }

        }


        if (isOpen)
        {
            Vector3 rot = this.transform.localEulerAngles;
            rot.y = Mathf.LerpAngle(rot.y, Open, 0.2f);
            this.transform.localEulerAngles = rot;
        }
        if (!isOpen)
        {
            Vector3 rot = this.transform.localEulerAngles;
            rot.y = Mathf.LerpAngle(rot.y, Close, 0.2f);
            this.transform.localEulerAngles = rot;
        }
    }
}
