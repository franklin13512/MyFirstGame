using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOfFires : MonoBehaviour
{
    public GameObject PositionOfFireA;
    public GameObject PositionOfFireB;
    public GameObject PositionOfFireC;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 2.0f;
        float height = 0.0025f;

        Vector3 newPosition1 = PositionOfFireA.transform.position;
        newPosition1.y += Mathf.Sin(Time.time * speed) * height;
        PositionOfFireA.transform.position = newPosition1;

        Vector3 newPosition2 = PositionOfFireB.transform.position;
        newPosition2.y += Mathf.Sin(Time.time * speed) * height;
        PositionOfFireB.transform.position = newPosition2;

        Vector3 newPosition3 = PositionOfFireC.transform.position;
        newPosition3.y += Mathf.Sin(Time.time * speed) * height;
        PositionOfFireC.transform.position = newPosition3;
    }
}
