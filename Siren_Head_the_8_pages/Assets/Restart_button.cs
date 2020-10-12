using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_button : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Samplescene");
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
       
}
