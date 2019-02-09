using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillsSuper : MonoBehaviour
{
    protected string skillName;
    protected string description;
    protected float energyCost;

    public abstract void SkillAction();
}
