using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlight_on_and_off : MonoBehaviour
{

    public Light flashlight;

    public AudioSource source;
    public AudioClip click;

    public Camera cam;

    public Siren_head SH;

    float flashlight_battery = 100;

    float flashlight_battery_loss = 0.01f;

    public Slider flashlight_bar;

    // Update is called once per frame
    void Update()
    {
        if (flashlight.isActiveAndEnabled)
        {
            flashlight_battery = flashlight_battery - flashlight_battery_loss*Time.deltaTime*60;
            if (Pause_screen.Pause_Screen.Unlimtedflashlight) 
            {
                flashlight_battery = 100;
            }

            if (flashlight_battery < 0)
            {
                flashlight.gameObject.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Fire1")&&Time.timeScale>0)
        {
            source.PlayOneShot(click);
            flashlight_hit();
            if (flashlight.isActiveAndEnabled)
            {
                flashlight.gameObject.SetActive(false);
            }
            else {
                flashlight.gameObject.SetActive(true);
            }

        }
        flashlight_bar.value = flashlight_battery / 100;
    }
    void flashlight_hit()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 40 ))
        {
           
            if (hit.transform.gameObject.tag== "Siren_head_hit")
            {
                SH.Siren_head_flicked();
            }
            
        }
    }
}
