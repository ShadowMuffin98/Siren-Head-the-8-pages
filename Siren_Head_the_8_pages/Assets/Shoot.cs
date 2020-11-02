using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rocket;
    public GameObject loaded;
    public AudioSource RPG_fire;
    public AudioSource RPG_reload_AS;
    public AudioClip RPG_reload_AC;
    bool Rocketdisable;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("interact")&&Rocketdisable==true)
        {
            loaded.SetActive(true);
            Rocketdisable = false;
            RPG_reload_AS.PlayOneShot(RPG_reload_AC);
            
        }


        if (Input.GetButtonDown("Shoot")&&Rocketdisable==false)
        {
            loaded.SetActive(false);
            Rocketdisable = true;
            RPG_fire.Play();
            GameObject newrocket = Instantiate(rocket);
            newrocket.transform.position = this.transform.position;
            newrocket.transform.forward = transform.forward;
        }
    }
}
