using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject PositionOfFire1;
    public GameObject PositionOfFire2;
    public GameObject PositionOfFire3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 2.0f;
        float height = 0.0025f;

        Vector3 newPosition1 = PositionOfFire1.transform.position;
        newPosition1.y += Mathf.Sin(Time.time * speed) * height; 
        PositionOfFire1.transform.position = newPosition1;

        Vector3 newPosition2 = PositionOfFire2.transform.position;
        newPosition2.y += Mathf.Sin(Time.time * speed) * height; 
        PositionOfFire2.transform.position = newPosition2;

        Vector3 newPosition3 = PositionOfFire3.transform.position;
        newPosition3.y += Mathf.Sin(Time.time * speed) * height; 
        PositionOfFire3.transform.position = newPosition3;
    }
}
