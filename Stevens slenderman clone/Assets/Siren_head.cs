using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren_head : MonoBehaviour
{
    public Collider col;
    public GameObject player;
    float distance = 50;
    float flashlight_flicks = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Move();
        }
    }

    public void Siren_head_flicked()
    {
        flashlight_flicks += 1;
        if (flashlight_flicks >3)
        {
            flashlight_flicks = 0;
            Move();
        }
            //If it is greater than 3, call Move() function 
            //and reset flashlight_flicks to 0
    }

    public void Move()
    {
        float angle = Random.Range(0f, 360f);
        angle = Mathf.Deg2Rad * angle;
        Vector3 offset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        this.transform.position = player.transform.position + offset*distance;
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
