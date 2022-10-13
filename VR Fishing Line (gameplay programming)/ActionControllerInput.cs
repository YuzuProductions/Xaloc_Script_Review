using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionControllerInput : MonoBehaviour
{
    public bool showController = false;
    private ActionBasedController controller;
    private GameObject spawnedController;
    public enum Controller { HMD, RightHand, LeftHand}
    public Controller controllerType;
    private XRController controllerScript;
    

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<ActionBasedController>();

        bool isPressed = controller.selectAction.action.ReadValue<bool>();

        controller.selectAction.action.performed += Action_performed;
        controller.activateAction.action.performed += Activate_Performed;

        if (controller != null)
        {
            //GameObject prefab = controller.modelPrefab.gameObject;
            //Debug.Log(prefab);
            //if (prefab)
            //{
            //    spawnedController = Instantiate(prefab, transform);
            //}
            //else
            //{
            //    Debug.LogError("Did not find corresponding controller model. Name is:" + controller.name);
            //}
        }

    }

    private void Activate_Performed(InputAction.CallbackContext obj)
    {
       //Debug.Log("Action Button is pressed");
    }

    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //Debug.Log("Select Button is pressed");
    }



    // Update is called once per frame
    void Update()
    {
        if (showController)
        {

        }
    }
}
