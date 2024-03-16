using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Explosionnnnnnnnn : MonoBehaviour
{
    public float MaxFifeTime;
    public ParticleSystem ExplosionAnimation;
    public AudioSource ExplosionAudioSouce;
    public LayerMask AllTank;
    public float ExplosionRadius;
    public float repel;
    public float MaxDamage;
    // Start is called before the first frame update
    void Start()
    {
        MaxFifeTime = 2f;
        Destroy(gameObject, MaxFifeTime);
        ExplosionRadius = 5f;
        repel = 1000f;
        MaxDamage = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius, AllTank);
        for(int i = 0; i < colliders.Length; i++)
        {
            Rigidbody AllTank_rb = colliders[i].GetComponent<Rigidbody>();
            AllTank_rb.AddExplosionForce(repel , transform.position, ExplosionRadius);

            float damage = ExplosionDamage(AllTank_rb.gameObject.transform.position);

            //Vector3 v3 = AllTank_rb.gameObject.transform.position - transform.position;
            //float distance = v3.magnitude;
            //float damage = (ExplosionRadius -  distance) / distance * MaxDamage;
            //damage = Mathf.Abs(damage);

            Health Hdamage = colliders[i].gameObject.GetComponent<Health>();
            if (Hdamage != null)
            {
                Hdamage.TakeDamage(damage);
            }
        }
        ExplosionAnimation.transform.parent = null;
        ExplosionAnimation.Play();

        Destroy(ExplosionAnimation.gameObject, ExplosionAnimation.main.duration);
        Destroy(gameObject);
    }
    private float ExplosionDamage(Vector3 GameObjectPosition)
    {
        Vector3 v3 = GameObjectPosition - transform.position;
        float distance = v3.magnitude;
        float damage = (ExplosionRadius - distance) / distance * MaxDamage;
        damage = Mathf.Abs(damage);

        return damage;
    }
}
