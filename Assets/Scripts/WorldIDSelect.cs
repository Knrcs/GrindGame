using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldIDSelect : MonoBehaviour
{
    public int worldID;

    public void AssignWorldID(int ID)
    {
        worldID = ID;
        Debug.Log("World ID set: " + worldID);
    }
}
