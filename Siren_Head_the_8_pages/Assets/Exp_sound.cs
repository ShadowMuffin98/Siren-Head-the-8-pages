using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Exp_AS;
    public AudioClip Exp_AC;
    void Start()
    {
        Exp_AS.PlayOneShot(Exp_AC);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
