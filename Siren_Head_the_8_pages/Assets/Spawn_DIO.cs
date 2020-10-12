using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_DIO : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Steamroller;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Steamroller.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
