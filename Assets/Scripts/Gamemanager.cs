using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager
        instance; //only one instance can exist at a time; All other classes have access to this instance


    [Header("UI")] 
    [SerializeField] private GameObject _interactUI;
    
    [Header("Player")] 
    public PlayerBehaviour player;
    private PlayerInput _playerInput;
    
    [Header("Hub Systems")]
    private WorldIDSelect _worldIDSelect;
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _worldIDSelect = GetComponent<WorldIDSelect>();
        _interactUI.SetActive(false);
    }

    public void DoTeleport()
    {
        //Teleport the player to the selected world from the Briefing Table

        switch (_worldIDSelect.worldID)
        {
            case 1:
                Debug.Log("Teleport to world 01");
                break;
            case 2:
                Debug.Log("Teleport to world 02");
                break;
            default:
                Debug.Log("No value is givin, doing nothing");
                break;
        }
    }

    public void ShowInteractUI(bool show)
    {
        _interactUI.SetActive(show);
    }
    
}
