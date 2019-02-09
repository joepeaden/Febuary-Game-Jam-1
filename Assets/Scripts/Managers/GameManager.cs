using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ActorSuper[] party;

    void Awake()
    {
        party = new ActorSuper[1];
        party[0] = new Healer();
    }
}
