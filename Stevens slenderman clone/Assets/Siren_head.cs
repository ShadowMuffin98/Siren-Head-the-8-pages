using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren_head : MonoBehaviour
{
    public Collider col;
    public GameObject player;
    public GameObject Siren_head_model;
    float distance = 50;
    float flashlight_flicks = 0;
    float move_count = 10;
    public float aggression = -1;
    public AudioSource AS;
    public GameObject head_cam;
    private void Start()
    {
        Siren_head_model.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        move_count -= Time.deltaTime;
        if (move_count <0 )
        {
            Move();
            move_count = 10;
        }
    }

    public void show_cam()
    {
        head_cam.SetActive(true);
    }
    public void Siren_head_flicked()
    {
        flashlight_flicks += 1;
        if (flashlight_flicks >3)
        {
            flashlight_flicks = 0;
            Move(40);
        }
        //If it is greater than 3, call Move() function 
        //and reset flashlight_flicks to 0
        
        //test{ }
    }
    public void aggravate()
    {
    aggression += 1;
    if (aggression >0)
        {
            Siren_head_model.SetActive(true);   
        }
    }
    public void Move(float extra_distance=0)
    {
          if (aggression <= 0) {
            return;

        }
        float D = distance - (aggression * 5);
        D += extra_distance; 
        float angle = Random.Range(0f, 360f);
        angle = Mathf.Deg2Rad * angle;
        Vector3 offset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        this.transform.position = player.transform.position + offset*D;
        Vector3 v = transform.position;
        v.y = Terrain.activeTerrain.SampleHeight(this.transform.position);
        this.transform.position = v;

       

    }

    bool VisibleOnCamera()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, col.bounds))
        {
            return true;
        }

        return false;
    }
}
