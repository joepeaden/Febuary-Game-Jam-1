using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject partyCombat;
    public GameObject enemyCombat;

    private ActorSuper[] enemies;

    void Start()
    {
        enemies = new ActorSuper[1];
        enemies[0] = new GoblinWarrior();
    }

    void Update()
    {
        
    }
}
