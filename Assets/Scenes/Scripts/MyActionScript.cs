using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MyActionScript : MonoBehaviour
{

    // a reference to the action
    public SteamVR_Action_Boolean SphereOnOff;

    // a reference to the hand
    public SteamVR_Input_Sources handType;

    //reference to the sphere
    public GameObject Blade;
    // Start is called before the first frame update
    void Start()
    {
        Blade.GetComponent<MeshRenderer>().enabled = false;
        SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        Blade.GetComponent<MeshRenderer>().enabled = false;
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        Blade.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
