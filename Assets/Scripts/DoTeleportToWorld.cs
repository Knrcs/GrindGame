using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTeleportToWorld : MonoBehaviour
{
    public Gamemanager _gamemanager;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _gamemanager.DoTeleport();
        }
    }
}
