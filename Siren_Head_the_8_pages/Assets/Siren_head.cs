using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren_head : MonoBehaviour
{
    public Collider col;
    public GameObject player;
    public GameObject Siren_head_model;
    public GameObject Siren_head_head_model;
    float distance = 50;
    float flashlight_flicks = 0;
    float move_count = 10;
    public float aggression = -1;
    public AudioSource AS;
    public AudioSource Siren_hurt;
    public GameObject head_cam;
    public AudioSource Siren_head_muffled;
    public List<cavebox> caveboxes;
    public List<Transform> cavepoints;
    public Animator animator;
    public Transform head_bone;
    private void Start()
    {
        Siren_head_model.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        head_cam.transform.LookAt(head_bone);

        move_count -= Time.deltaTime;
        if (move_count <0 )
        {
            Move();
            move_count = 10;
            if (Playerincave())
            {
                move_count = 7;
            }
        }
    }

    public void show_cam()
    {
        head_cam.SetActive(true);
        animator.SetBool("Eating",true);
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
        if (aggression > 5)
        {
            animator.SetBool("Spin", true);
        }
        if (aggression >0)
        {
            if (Playerincave())
            {
                Siren_head_head_model.SetActive(true);
            }
            else
            {
                Siren_head_model.SetActive(true);
            }
            Siren_head_muffled.volume = 0.75f;
        }
    }
    public void Move(float extra_distance = 0)
    {
        if (aggression <= 0)
        {
            return;

        }
        if (Playerincave())
        {
            movecave();
            Siren_head_model.SetActive(false);
            Siren_head_head_model.SetActive(true);
        }
        else
        {
            if (aggression > 5)
            {
                animator.SetBool("Spin", true);
            }
            this.transform.localEulerAngles = Vector3.zero;
            Siren_head_model.SetActive(true);
            Siren_head_head_model.SetActive(false);
            float D = distance - (aggression * 5);
            D += extra_distance;
            float angle = Random.Range(0f, 360f);
            angle = Mathf.Deg2Rad * angle;
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            this.transform.position = player.transform.position + offset * D;
            Vector3 v = transform.position;
            v.y = Terrain.activeTerrain.SampleHeight(this.transform.position);
            this.transform.position = v;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position + Vector3.down, (Vector3.up), out hit, Mathf.Infinity))
            {
                Move(extra_distance);
            }
        }
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
    public bool Playerincave()
    {
        foreach(cavebox box in caveboxes)
        {
            if (box.inbox)
            {
                return true;
            }
        }
        return false;
    }
    void movecave()
    {
        float d = 9999;
        Transform cloestcavepoint = null;
        foreach (Transform p in cavepoints)
        {
            float distance = Vector3.Distance(player.transform.position, p.transform.position);
            if (distance<d)
            {
                d = distance;
                cloestcavepoint = p;
            }
        }


        
        transform.position = cloestcavepoint.position;
        transform.rotation = cloestcavepoint.rotation;
    }
}
