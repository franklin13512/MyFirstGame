using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Instanciate2 : MonoBehaviour
{
    public GameObject tank;
    public GameObject camera1;
    public GameObject Newtank;
    public GameObject ACamera;

    private Vector3 PositionOfCamera;
    private Vector3 NewTankPosition;
    private Health Weakness;
    
    // Start is called before the first frame update
    void Start()
    {
        camera1.gameObject.SetActive(true);

    }
    private void OnEnable()
    {
        PositionOfCamera = new Vector3(transform.position.x - 10, transform.position.y + 11, transform.position.z - 7);
        Newtank = Instantiate(tank, transform.position, transform.rotation);


        FollowTank1 yourScriptComponent = camera1.GetComponent<FollowTank1>();
        yourScriptComponent.Tank1 = Newtank;
        ACamera =  Instantiate(camera1, PositionOfCamera, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTank1 yourScriptComponent = camera1.GetComponent<FollowTank1>();
        yourScriptComponent.Tank1 = Newtank;


        if (!Newtank.gameObject.activeSelf)
        {
            Weakness = Newtank.GetComponent<Health>();
            Weakness.PositionOfWeakness.gameObject.SetActive(false);
            Weakness.PositionOfWeakness2.gameObject.SetActive(false);

            NewTankPosition = new Vector3(-2, 0, 30);
            Newtank.transform.position = NewTankPosition;
            
            Newtank.gameObject.SetActive(true);

            
        }

    }

}
