using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Unlock", 1);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
