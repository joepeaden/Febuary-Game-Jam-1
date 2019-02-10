using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    private GameManager gm;
    public GameObject[] enemies;

    public GameObject partyCombatLoc;
    public GameObject enemyCombatLoc;

    public GameObject actionSelect;
    public GameObject skillSelect;
    public GameObject turnRotation;

    private Queue<GameObject> queue;
    private GameObject activePlayer;

    void Awake()
    {
        enemies = new GameObject[1];
        enemies[0] = Instantiate((GameObject)Resources.Load("Prefabs/Actors/Enemies/GoblinWarrior"));
    }

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        gm.party[0].transform.position = partyCombatLoc.transform.GetChild(0).transform.position;
        enemies[0].transform.position = enemyCombatLoc.transform.GetChild(0).transform.position;

        activePlayer = gm.party[0];
        Debug.Log(activePlayer.GetComponent<ActorSuper>().charName + "'s turn.");
        //Transform textQueue = turnRotation.transform.GetChild(1);  

        queue = new Queue<GameObject>();
        for (int i = 0; i < enemies.Length; i++)
        {
            queue.Enqueue(enemies[i]);
            //textQueue.transform.GetChild(0).GetComponent<Text>().text = enemies[i].charName
        }
    }

    public void ActionButton()
    {
        actionSelect.SetActive(false);
        skillSelect.SetActive(true);
    }

    public void SkillSelection(int skillNum)
    {
        skillSelect.SetActive(false);

        activePlayer.GetComponent<ActorSuper>().skills[skillNum].SkillAction(enemies[0]);

        NextPlayer();
    }

    public void NextPlayer()
    {
        queue.Enqueue(activePlayer);
        activePlayer = queue.Dequeue();
        Debug.Log(activePlayer.GetComponent<ActorSuper>().charName + "'s turn.");

        while(activePlayer.CompareTag("Enemy"))
        {
            EnemyAction();

            queue.Enqueue(activePlayer);
            activePlayer = queue.Dequeue();
            Debug.Log(activePlayer.GetComponent<ActorSuper>().charName + "'s turn.");
        }

        actionSelect.SetActive(true);
    }

    private void EnemyAction()
    {
        ActorSuper actor = activePlayer.GetComponent<ActorSuper>();

        //select action to take
        SkillsSuper skill = AI.SelectSkill(actor);

        // select target for enemy
        GameObject enemy_target = AI.FindTarget(skill, gm.party, enemies);
        
        // skill will be null
        if(skill != null)
            skill.SkillAction(enemy_target);
    }
}
