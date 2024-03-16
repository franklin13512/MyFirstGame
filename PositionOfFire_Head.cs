using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOfFire_Head : MonoBehaviour
{
    public GameObject PositionOfFireA;
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
    }
}
