using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavebox : MonoBehaviour
{
    public bool inbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            inbox = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            inbox = (false);
        }
    }
}
