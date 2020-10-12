using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Exp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward *25* Time.fixedDeltaTime, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Siren_head>())
        {
            collision.gameObject.GetComponent<Siren_head>().Siren_head_flicked();
        }
        if (collision.gameObject.tag == "Tree")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }



        GameObject newexplosion = Instantiate(Exp);
        newexplosion.transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
