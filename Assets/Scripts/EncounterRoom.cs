using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterRoom : Room
{
    override public void SetExplored(bool isExplored)
    {
        if(isExplored)
            GenerateEncounter();
        base.SetExplored(isExplored);
    }

    private void GenerateEncounter()
    {
        Debug.Log("An encounter takes place!");
    }
}
