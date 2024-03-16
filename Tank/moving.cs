using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public int PlayerNumber;
    public float speed;
    public float turnspeed;
    public AudioSource MovingAudio;
    public AudioClip EngineIdle;
    public AudioClip EngineDriving;
    public float EngineAudioPitchRange;
    


    private Rigidbody rb;
    private string HorizontalInputName;
    private string VerticalInputName;
    private float HorizontalInputValue;
    private float VerticalInputValue;
    private float Original_EngineAudioPitch;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //PlayerNumber = 1;
        HorizontalInputName = "Horizontal" + PlayerNumber;
        VerticalInputName = "Vertical" + PlayerNumber;
        speed = 20.0f;
        turnspeed = 200.0f;
        EngineAudioPitchRange = 0.2f;
        Original_EngineAudioPitch = MovingAudio.pitch;
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInputValue = Input.GetAxis(HorizontalInputName);
        VerticalInputValue = Input.GetAxis(VerticalInputName);
        MovementSound();
        
    }

    private void FixedUpdate()
    {
        move();
        turn();
    }
    void move()
    {
        Vector3 MoveDistence = transform.forward * VerticalInputValue * Time.deltaTime * speed;
        rb.MovePosition(transform.position + MoveDistence);
        //Debug.Log(VerticalInputValue);
    }
    void turn()
    {
        float turn = HorizontalInputValue * Time.deltaTime * turnspeed;
        Quaternion quaternion = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * quaternion);
        //Debug.Log(HorizontalInputValue);
    }
    void MovementSound()
    {
        if((Mathf.Abs(HorizontalInputValue) <= 0.2)&&(Mathf.Abs(VerticalInputValue) <= 0.2))
        {
            if(MovingAudio.clip == EngineDriving)
            {
                MovingAudio.clip = EngineIdle;
                MovingAudio.pitch = Random.Range(Original_EngineAudioPitch - EngineAudioPitchRange, Original_EngineAudioPitch + EngineAudioPitchRange);
                MovingAudio.Play();
            }
        }
        else
        {
            if (MovingAudio.clip == EngineIdle)
            {
                MovingAudio.clip = EngineDriving;
                MovingAudio.pitch = Random.Range(Original_EngineAudioPitch - EngineAudioPitchRange, Original_EngineAudioPitch + EngineAudioPitchRange);
                MovingAudio.Play();
            }
        }
    }
    
}
