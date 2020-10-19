using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        float Unlock = PlayerPrefs.GetFloat("Unlock", 0);
        if (Unlock == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
