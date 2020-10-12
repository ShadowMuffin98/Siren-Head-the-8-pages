using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steamroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject Exp;
    public AudioSource AS;
    public AudioClip Roadroller;
    void Start()
    {
        AS.PlayOneShot(Roadroller);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, .025f * Time.deltaTime * 60);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            GameObject newexplosion = Instantiate(Exp);
            newexplosion.transform.position = this.transform.position;
            player.GetComponent<Hp>().steamroller_death();
            Destroy(gameObject);
        }
    }
}
