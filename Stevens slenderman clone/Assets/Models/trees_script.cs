using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trees_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            Vector3 childpos = child.localPosition; 
            childpos.y = 0;
            childpos.x = 0;
            childpos.z = 0;
            child.localPosition = childpos;

        }

        Vector3 pos = transform.position;
        pos.x = Random.Range(-239.43f, 259.48f);
        pos.z = Random.Range(-203f, 295.9f);
        pos.y = Terrain.activeTerrain.SampleHeight(pos) + 15;
        transform.position = pos;



        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;


        RaycastHit hit;
        Vector3 v = transform.position + Vector3.down * 100;
        if (Physics.Raycast(v, Vector3.up, out hit, Mathf.Infinity, layerMask))
        {
            gameObject.SetActive(false);

            Debug.Log("Did Hit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
