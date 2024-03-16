using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject tank;
    public GameObject camera2;
    public GameObject Newtank;
    public GameObject ACamera;

    private Vector3 PositionOfCamera;
    private Vector3 NewTankPosition;
    private Health Weakness;
    // Start is called before the first frame update
    void Start()
    {
        camera2.gameObject.SetActive(true);

    }
    private void OnEnable()
    {
        Vector3 PositionOfCamera = new Vector3(transform.position.x - 12, transform.position.y + 11, transform.position.z - 8);
        Newtank = Instantiate(tank, transform.position, transform.rotation);


        FollowTank1 yourScriptComponent = camera2.GetComponent<FollowTank1>();
        yourScriptComponent.Tank1 = Newtank;
        ACamera = Instantiate(camera2, PositionOfCamera, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTank1 yourScriptComponent = camera2.GetComponent<FollowTank1>();
        yourScriptComponent.Tank1 = Newtank;


        if (!Newtank.gameObject.activeSelf)
        {
            Weakness = Newtank.GetComponent<Health>();
            Weakness.PositionOfWeakness.gameObject.SetActive(false);
            Weakness.PositionOfWeakness2.gameObject.SetActive(false);

            NewTankPosition = new Vector3(8, 0, 0);
            Newtank.transform.position = NewTankPosition;

            Newtank.gameObject.SetActive(true);


        }

    }
}

