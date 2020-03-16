using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public Image image;
    public Text text;
    int page = 0;




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

    void OnCollisionEnter(Collision collision)
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
        yield return new WaitForSeconds(2);
        //5 seconds have passed
        text.gameObject.SetActive(false);
    }


}
