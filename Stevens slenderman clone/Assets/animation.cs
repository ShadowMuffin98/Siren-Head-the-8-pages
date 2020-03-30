using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public List<Texture> frames;
    public Renderer renderer;
    int frames_count = 0;
    float timer= 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTexture = frames[frames_count];
        renderer.material.SetTexture("_EmissionMap", frames[frames_count]);

        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            timer = 0;
            frames_count += 1;
            if (frames_count > 17)
            {
                frames_count = 0;
            }
        }
    }
}
