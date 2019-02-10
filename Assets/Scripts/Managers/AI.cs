using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AI
{

    public static GameObject FindTarget(SkillsSuper skill, GameObject[] oppositeTeam, GameObject[] myTeam)
    {

        //if()
        GameObject target = GangUp(oppositeTeam);

        return target;
    }

    // find target with minimum health, attack that target
    private static GameObject GangUp(GameObject[] oppositeTeam)
    {
        // default to target 1st opposite team member
        GameObject target = oppositeTeam[0];
        float min = 0;

        foreach (GameObject g in oppositeTeam)
        {
            ActorSuper actor = g.GetComponent<ActorSuper>();

            float temp = actor.GetHealth();
            if (temp < min)
            {
                min = temp;
                target = g;
            }
        }

        return target;
    }

    public static SkillsSuper SelectSkill(ActorSuper actor)
    {
        if (actor.skills.Length == 1)
            return actor.skills[0];

        if (actor is GoblinWarrior)
        {
            Debug.Log("Warrior");
            return actor.skills[0];
        }

        return actor.skills[0];
    }

}
