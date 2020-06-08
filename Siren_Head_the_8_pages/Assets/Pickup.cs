using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public Image image;
    public Text text;
    int page = 0;
    public Siren_head SH;
    public AudioClip Siren_head_coming;
    public AudioSource AS;
    public AudioClip Page_pickup;




    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(ShowText());
        text.text = "collected 0 of 8 pages";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Pick_up_cube>())
        {
            image.sprite = collision.gameObject.GetComponent<Pick_up_cube>().popup;
            image.gameObject.SetActive(true);
            Destroy(collision.gameObject);
            page = page + 1;
            text.text = "collected "+ page.ToString() + " of 8 pages";
            StartCoroutine(ShowText());
        }
    }
    IEnumerator ShowText()
    {
        //0 seconds have passed
        text.gameObject.SetActive(true);
        if (page > 0)
        {
            AS.PlayOneShot(Page_pickup);
        }
        yield return new WaitForSeconds(2);
        //5 seconds have passed
        if (page==1)
        {
            //SH.AS.PlayOneShot(Siren_head_coming);
        }
        SH.aggravate();
        text.gameObject.SetActive(false);
    }


}
