using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FollowTank1 : MonoBehaviour
{
    public GameObject Tank1;
    Vector3 distance;
    Vector3 v3;
    float DampTime;
    // Start is called before the first frame update
    void Start()
    {
        DampTime = 0.5f;
        distance = transform.position - Tank1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 OldPosition = transform.position;
        transform.position = Tank1.transform.position + distance;
        Vector3 NewPosition = transform.position;
        transform.position = Vector3.SmoothDamp(OldPosition, NewPosition, ref v3, DampTime);
    }
}
