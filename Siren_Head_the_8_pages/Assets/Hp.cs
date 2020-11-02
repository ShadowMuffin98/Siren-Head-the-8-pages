using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    public List<Siren_head> SH_list;
    public float Health = 100;
    float regeneration = 0.3f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool found_any_SH = false;
        foreach (Siren_head SH in SH_list)
        {
            float dis = Vector3.Distance(this.transform.position, SH.transform.position);
            if (dis < 25)

            {
                found_any_SH = true;
                SH.Siren_hurt.volume = 1;
                if (SH.Playerincave())
                {
                    Health -= 0.2f;
                }
                else
                {
                    Health -= 0.4f;
                }
                if (Health < 1)
                {
                    SH.show_cam();
                    StartCoroutine(Gameover());
                }
            }
            else
            {
                SH.Siren_hurt.volume = 0;
            }

        }
        if (found_any_SH == false)
        {
            if (Health < 100)
            {
                Health += regeneration;
            }
        }






    }
    public IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene("Gameover");

    }
    public IEnumerator FastGameover()
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadScene("Gameover");

    }
    public void steamroller_death()
    {
        StartCoroutine(FastGameover());
    }
}
