using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DDManager : MonoBehaviour
{

    public GameObject rig;
    public GameObject[] spawnPoints;
    private int count = 0;
    private XRController controller;
    private bool flag = true;
    private int p = 0;
    private bool pressedCheck = false;
    


    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rig.transform.position = spawnPoints[count].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (pressedCheck == false) {
            flag = true;
        }*/
        controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed);
        if (pressed && flag) {
            flag = false;
            Debug.Log(p);
            p++;
            gotoNextEncounter();
            StartCoroutine(waitCoroutine());
            //pressed = false;

        }
    }

    void gotoNextEncounter() {
        count++;
        if (count >= spawnPoints.Length)
            count = 0;
        rig.transform.position = spawnPoints[count].transform.position;
        rig.transform.rotation = spawnPoints[count].transform.rotation;
    }

    
    IEnumerator waitCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        flag = true;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    
}
