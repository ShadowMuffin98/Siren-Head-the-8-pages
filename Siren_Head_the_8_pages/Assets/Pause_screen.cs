using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Pause_screen : MonoBehaviour
{
    public static Pause_screen Pause_Screen;
    public bool RPG;
    public bool Unlimtedflashlight;
    public bool Daylight;
    public bool MoreSirenheads;
    public bool Pause;
    public bool Unlockables;
    public GameObject Pause_UI;
    public GameObject RPG_Object;
    public GameObject RPG_Rocket_Object;
    public GameObject Day;
    public GameObject Sirenhead;
    public GameObject Unlockables_Object;
    public Hp player_HP;
    public FirstPersonController FPS;
    public GameObject Unlockable_button;
    public GameObject defaultbutton;
    // Start is called before the first frame update
    void Awake()
    {
        if (Pause_Screen == null)

        {
            Pause_Screen = this;
        }
        float Unlock = PlayerPrefs.GetFloat("Unlock", 0);
        if (Unlock == 0) 
        {
            Unlockable_button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (Pause)
            {
                Pause_off();
            }
            else
            {
                Pause_on();
            }
        }
    }
    public void Pause_on()
    {
        Pause = true;
        Pause_UI.SetActive(true);
        Time.timeScale = 0;
        FPS.enabled = false;
        EventSystem.current.SetSelectedGameObject(defaultbutton);
   
    }
    public void Pause_off()
    {
        Pause = false;
        Pause_UI.SetActive(false);
        Time.timeScale = 1;
        FPS.enabled = true;
    }

    public void Toggle_RPG()
    {
        RPG = !RPG;
        RPG_Object.SetActive(RPG);
        RPG_Rocket_Object.SetActive(RPG);

    }
    public void Toggle_Unlimtedflashlight()
    {
        Unlimtedflashlight = !Unlimtedflashlight;
    }
    public void Toggle_Daylight()
    {
        Daylight = !Daylight;
        Day.SetActive(Daylight);
    }
    public void Toggle_MoreSirenheads()
    {
        MoreSirenheads = !MoreSirenheads;
        GameObject New_siren_Head = Instantiate(Sirenhead);
        Siren_head SH = New_siren_Head.GetComponent<Siren_head>();
        player_HP.SH_list.Add(SH);
    }
    public void Toggle_Unlockables()
    {
        Unlockables = !Unlockables;
        Unlockables_Object.SetActive(Unlockables);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

}
