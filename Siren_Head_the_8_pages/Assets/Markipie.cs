using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Markipie : MonoBehaviour
{
    bool touch = false;
    public GameObject jumpscare;
    public AudioSource Markipie_sound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("interact"))
        {
            GameObject p = GameObject.Find("Player");
            float dis = Vector3.Distance(transform.position, p.transform.position);
            if (dis < 2.5)
            {
                touch = true;
                Markipie_sound.Play();
                StartCoroutine(hide());
            }

        }


        if (touch)
        {
            
            transform.position = Vector3.Lerp(transform.position, jumpscare.transform.position, 0.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, jumpscare.transform.rotation, 0.2f);
        }
    }
    IEnumerator hide()
    {
        yield return new WaitForSeconds(2.5f);
        this.transform.gameObject.SetActive(false);
    }

}
