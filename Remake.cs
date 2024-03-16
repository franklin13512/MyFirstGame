using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remake : MonoBehaviour
{
    public GameObject tankPrefab; // Reference to the tank prefab

    private Health death; // Cached Health component

    void Start()
    {
        // Cache the Health component
        
    }

    void Update()
    {
        death = tankPrefab.GetComponent<Health>();
        if (death != null && death.HadDead)
        {
            // Instantiate the tank prefab
            Instantiate(tankPrefab, transform.position, transform.rotation);
        }
    }
}