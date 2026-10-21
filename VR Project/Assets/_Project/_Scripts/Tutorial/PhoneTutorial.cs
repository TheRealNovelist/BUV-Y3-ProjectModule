using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTutorial : MonoBehaviour
{
    [SerializeField] private GameObject pointerTutObj; 
    private bool pointerTutorial;
    
    private void Awake()
    {
        Phone.OnPhoneAction += OnPhoneAction;
        Phone.OnPhoneReturn += OnPhoneReturn;
        Phone.OnPhoneTaken += OnPhoneTaken;
    }

    private void OnDestroy()
    {
        Phone.OnPhoneAction -= OnPhoneAction;
        Phone.OnPhoneReturn -= OnPhoneReturn;
        Phone.OnPhoneTaken -= OnPhoneTaken;
    }

    private void OnPhoneReturn()
    {
        if (!pointerTutorial) pointerTutObj.SetActive(false);
    }
    
    private void OnPhoneTaken()
    {
        if (!pointerTutorial) pointerTutObj.SetActive(true);
    }
    
    private void OnPhoneAction(string action)
    {
        if (!pointerTutorial && action == "Unlock Screen")
        {
            pointerTutObj.SetActive(false);
            pointerTutorial = true;
        }
    }
}
