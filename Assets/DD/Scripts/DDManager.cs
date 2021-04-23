using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DDManager : MonoBehaviour
{

    public GameObject rig;
    public GameObject[] spawnPoints;
    private XRController controller;
    //private bool pressed;


    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed)) {
            Debug.Log("Button Pressed");
        }
    }
}
