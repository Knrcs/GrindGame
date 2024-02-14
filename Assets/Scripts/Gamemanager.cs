using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private WorldIDSelect _worldIDSelect;
    private void Awake()
    {
        _worldIDSelect = GetComponent<WorldIDSelect>();
    }

    public void DoTeleport()
    {
        Debug.Log(_worldIDSelect.worldID + "World");
    }
}
