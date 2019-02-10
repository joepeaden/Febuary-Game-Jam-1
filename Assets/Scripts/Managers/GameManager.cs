using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] party;

    void Awake()
    {
        party = new GameObject[1];
        party[0] = Instantiate((GameObject)Resources.Load("Prefabs/Actors/Party/Healer"));
    }
}
