using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public string ShootingButtom;
    public int PlayerNumber;
    public GameObject FirePositon;
    public GameObject Shell;
    public Slider ShootSlider;
    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentForceSpeed;
    public float ChargeTime;
    public float ChargeSpeed;
    public AudioSource ShootingAudio;
    public AudioClip ChargingClip;
    public AudioClip FireClip;
    public ParticleSystem ExplosionAnimation;

    private bool HadFire;
    private Rigidbody rb3;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerNumber = 1;
        MinSpeed = 20f;
        MaxSpeed = 40f;
        ChargeTime = 0.75f;
        ShootingButtom = "Fire" + PlayerNumber;
        ChargeSpeed = (MaxSpeed - MinSpeed) / ChargeTime;
        rb3 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        ShootSlider.value = 0;
        if (Input.GetButtonDown(ShootingButtom))
        {
            CurrentForceSpeed = MinSpeed;
            HadFire = false;
        }else if (Input.GetButton(ShootingButtom) && !HadFire) {
           
            CurrentForceSpeed += ChargeSpeed * Time.deltaTime;

            ShootSlider.value = (CurrentForceSpeed - MinSpeed)/MaxSpeed ;
            if (ShootingAudio.clip == FireClip)
            {
                ShootingAudio.clip = ChargingClip;
                ShootingAudio.Play();
            }
            if (CurrentForceSpeed >= MaxSpeed)
            {
                CurrentForceSpeed = MaxSpeed;
                GameObject GOB1 = Instantiate(Shell, FirePositon.transform.position, FirePositon.transform.rotation);
                Rigidbody rb2 = GOB1.GetComponent<Rigidbody>();
                //ExplosionAnimation.Play();
                rb2.velocity = FirePositon.transform.forward * CurrentForceSpeed;
                CurrentForceSpeed = MinSpeed;


                HadFire = true;
                if (ShootingAudio.clip != FireClip)
                {
                    ShootingAudio.clip = FireClip;
                    ShootingAudio.Play();
                    ExplosionAnimation.Play();
                }
            }
           
        }else if(Input.GetButtonUp(ShootingButtom) && !HadFire)
        {
            
            GameObject GOB1 = Instantiate(Shell, FirePositon.transform.position, FirePositon.transform.rotation);
            Rigidbody rb2 = GOB1.GetComponent<Rigidbody>();
            
            rb2.velocity = FirePositon.transform.forward * CurrentForceSpeed;
            
            CurrentForceSpeed = MinSpeed;
            HadFire = true;
            if (ShootingAudio.clip != FireClip)
            {
                ShootingAudio.clip = FireClip;
                ShootingAudio.Play();
                ExplosionAnimation.Play();
            }
        }
    }
}
