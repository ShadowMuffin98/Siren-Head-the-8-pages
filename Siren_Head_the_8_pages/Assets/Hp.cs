using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    public Siren_head SH;
    public float Health = 100;
    float regeneration = 0.2f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(this.transform.position, SH.transform.position);
        if (dis<25)

        {
            SH.Siren_hurt.volume = 1;
            Health -= 0.5f;
            if (Health <1)
            {
                SH.show_cam();
                StartCoroutine(Gameover());
            }
        }
        else 
        {
            SH.Siren_hurt.volume = 0;
            if (Health <100)
            {
                Health += regeneration;
            }
        }
        
    }
    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Gameover");

    }

}
