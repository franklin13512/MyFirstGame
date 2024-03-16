using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MStartingHealth = 100f;
    public GameObject ExplosionPrefab;
    public ParticleSystem ExplosionParticles;
    public AudioSource ExplosionSounds;
    public Image FullHealthImage;
    public Color FullHealthColor = Color.green;
    public Color WeakHealthColor = Color.yellow;
    public Color ZeroHealthColor = Color.red;
    public GameObject Wreckage;
    public GameObject WreckageHead;
    public GameObject PositionOfWreckageHead;
    public GameObject PositionOfWeakness;
    public GameObject PositionOfWeakness2;
    public GameObject ExpolosionLight;
    public ParticleSystem Weakness;
    public ParticleSystem Weakness2;
    public Slider HealthSlider;
    public Light LightForWeakness;
    public Light LightForWeakness2;
    //public GameObject ReMakeTank;
    //public GameObject NewACamera;

    public bool HadDead;
    private float CurrentHealth;
    private Vector3 PositionOfCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        ExplosionParticles = Instantiate(ExplosionPrefab).GetComponent<ParticleSystem>();
        ExplosionSounds = ExplosionParticles.GetComponent<AudioSource>();
        Weakness = PositionOfWeakness.GetComponent<ParticleSystem>();
        Weakness2 = PositionOfWeakness2.GetComponent<ParticleSystem>();
        LightForWeakness = PositionOfWeakness.GetComponent<Light>();
        LightForWeakness2 = PositionOfWeakness2.GetComponent<Light>();

        ExplosionParticles.gameObject.SetActive(false);
        LightForWeakness.gameObject.SetActive(false);
        LightForWeakness2.gameObject.SetActive(false);
        Weakness.gameObject.SetActive(false);
        Weakness2.gameObject.SetActive(false);

        //PositionOfCamera = new Vector3(ReMakeTank.transform.position.x - 6, ReMakeTank.transform.position.y + 11, ReMakeTank.transform.position.z - 4);

    }
    private void OnEnable()
    {
        CurrentHealth = MStartingHealth;
        HadDead = false;
        HealthUI();
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        HealthUI();
        
        if (CurrentHealth <= 0 && HadDead != true) {
            OnDeath();
            //Remake();
        }
        Debug.Log(CurrentHealth);

    }
    // Update is called once per frame
    void Update()
    {
        POW1(PositionOfWeakness ,Weakness ,LightForWeakness);
        POW2(PositionOfWeakness2 ,Weakness2);
    }
    private void POW1(GameObject PositionOfWeakness, ParticleSystem Weakness ,Light LightForWeakness)
    {
        if (CurrentHealth <= 68 && HadDead != true)
        {
            float speed = 2.0f;
            float height = 0.0025f;


            Weakness.gameObject.SetActive(true);
            LightForWeakness.enabled = false;
            Vector3 newPosition = PositionOfWeakness.transform.position;
            newPosition.y += Mathf.Sin(Time.time * speed) * height;
            PositionOfWeakness.transform.position = newPosition;
            if(CurrentHealth < 68 && HadDead != true)
            {
                LightForWeakness.enabled = true;
            }
            //GameObject weakness = Instantiate(PositionOfWeakness);
        }
    }
    private void POW2(GameObject PositionOfWeakness, ParticleSystem Weakness)
    {
        if (CurrentHealth < 45 && HadDead != true)
        {
            float speed = 2.0f;
            float height = 0.0025f;


            Weakness.gameObject.SetActive(true);
            Vector3 newPosition = PositionOfWeakness.transform.position;
            newPosition.y += Mathf.Sin(Time.time * speed) * height;
            PositionOfWeakness.transform.position = newPosition;
            //GameObject weakness = Instantiate(PositionOfWeakness);
        }
    }
    private void OnDeath()
    {
        Vector3 PositionOfExplosionParticle = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        ExplosionParticles.transform.position = PositionOfExplosionParticle;
        ExplosionParticles.gameObject.SetActive(true);
        ExplosionParticles.Play();
        ExplosionSounds.Play();

        Vector3 PositionOfExplosionLight = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        GameObject GO = Instantiate(ExpolosionLight, PositionOfExplosionLight, transform.rotation);
        Destroy(GO, ExplosionParticles.main.duration);

        HadDead = true;
        gameObject.SetActive(false);

        GameObject wreckage = Instantiate(Wreckage, transform.position, transform.rotation);
        GameObject wreckage_Haed = Instantiate(WreckageHead, PositionOfWreckageHead.transform.position, PositionOfWreckageHead.transform.rotation);

        Rigidbody rb = wreckage_Haed.GetComponent<Rigidbody>();
        rb.velocity = wreckage.transform.up * 10;
    }
    private void HealthUI()
    {
        HealthSlider.value = CurrentHealth/MStartingHealth;
        if(CurrentHealth > 50)
        {
            FullHealthImage.color = Color.Lerp(WeakHealthColor, FullHealthColor, (CurrentHealth/2) / MStartingHealth);
        }else if(CurrentHealth <= 50) {
            FullHealthImage.color = Color.Lerp(ZeroHealthColor, WeakHealthColor, CurrentHealth / (MStartingHealth/2));
        }
    }
    //private void Remake()
    //{

    //    Vector3 NewYPosition = transform.up * 5;
    //    //Instanciate CameraRig = ReMakeTank.GetComponent<Instanciate>();
    //    //NewACamera = CameraRig.ACamera;
    //    Instanciate2 CameraRig2 = ReMakeTank.GetComponent<Instanciate2>();
    //    NewACamera = CameraRig2.ACamera;
    //    Destroy(NewACamera);
    //    Instantiate(ReMakeTank, NewYPosition, transform.rotation);
    //    //Instanciate NewTank1 = ReMakeTank.GetComponent<Instanciate>();
    //    //ReMakeTank = NewTank1.tank;
    //    Instanciate2 NewTank2 = ReMakeTank.GetComponent<Instanciate2>();
    //    ReMakeTank = NewTank2.tank;
    //    NewACamera = Instantiate(CameraRig2.ACamera, PositionOfCamera, transform.rotation);

    //}

}
