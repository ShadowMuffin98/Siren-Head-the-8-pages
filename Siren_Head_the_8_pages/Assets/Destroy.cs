using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitandDestroy()); 
    }

    IEnumerator WaitandDestroy ()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    
}      
