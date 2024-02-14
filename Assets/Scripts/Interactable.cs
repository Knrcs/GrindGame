using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string interactAnimation;
    public UnityEvent onInteract;

    private void OnDisable()
    {
        if (Gamemanager.instance.player.currentinteractable == this)
        {
            Gamemanager.instance.player.currentinteractable = null;
        }
        Gamemanager.instance.ShowInteractUI(false);
    }
}