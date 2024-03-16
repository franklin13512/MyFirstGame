using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMove : MonoBehaviour
{
    private Camera m_Camera;
    private Vector3 DesiredPosition;
    private Vector3 vect;
    private float flo;

    public float TimeForDamp;
    public Transform[] targets;
    public float ScreemBuffer;
    public float MinSize;

    // Start is called before the first frame update
    private void Awake()
    {
        TimeForDamp = 0.2f;
        m_Camera = GetComponentInChildren<Camera>();
        ScreemBuffer = 4f;
        MinSize = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        AveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position ,DesiredPosition ,ref vect , TimeForDamp);

    }
    private void AveragePosition()
    {
        float num = 0;
        Vector3 PosiotionOfAverage = new Vector3();
        for(int i = 0 ;i < targets.Length; i++)
        {
           if(!targets[i].gameObject.activeSelf)
            {
                continue;
            }
            PosiotionOfAverage += targets[i].transform.position;
            num++;

            if(num > 0 )
            {
                PosiotionOfAverage /= num;
                PosiotionOfAverage.y = transform.position.y;
                DesiredPosition = PosiotionOfAverage;
            }
        }
    }
    
}
