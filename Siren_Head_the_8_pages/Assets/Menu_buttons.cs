using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_buttons : MonoBehaviour
{
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start_Game()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        bool Credits_on = credits.activeSelf;
        credits.SetActive(!Credits_on);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
