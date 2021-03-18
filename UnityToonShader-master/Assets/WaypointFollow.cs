using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{       

    public GameObject[] waypoints;  
    int currentWP = 0;

    float speed = 1.0f;
    float accuracy = 1.0f;
    float rotSpeed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
      //Vai Localizar os Gameobjects com a Tag inserida.  
      waypoints= GameObject.FindGameObjectsWithTag("waypoint");                
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Se o Lenght do waypoint for igual a 0 ele retorna.
        if (waypoints.Length == 0) return;

        //Controla a Direção do Objeto, para onde ele vai e sua Rotação
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position; this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        //Faz ele ir pro próximo Waypoint
        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }

        }
        //Faz o Gameobject se Mover
        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
