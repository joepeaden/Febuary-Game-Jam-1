﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillsSuper : MonoBehaviour
{
    public string skillName;
    public string description;
    public float energyCost;

    public abstract void SkillAction(GameObject target);
    //public abstract bool ViableAction(GameObject activePlayer, GameObject target)
}
