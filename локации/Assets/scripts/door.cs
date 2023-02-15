using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
