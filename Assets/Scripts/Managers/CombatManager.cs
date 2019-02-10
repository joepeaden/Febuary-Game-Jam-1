using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    private enum Mode {actionSelect, enemySelect, enemyTurn};
    private Mode mode;

    private GameManager gm;
    public GameObject[] enemies;

    public GameObject partyCombatLoc;
    public GameObject enemyCombatLoc;

    public GameObject actionSelect;
    public GameObject skillSelect;
    public GameObject turnRotation;

    private Queue<GameObject> queue;
    private GameObject activePlayer;

    private GameObject target;
    private int skillSelection;

    void Awake()
    {
        enemies = new GameObject[1];
        enemies[0] = Instantiate((GameObject)Resources.Load("Prefabs/Actors/Enemies/GoblinWarrior"));

        mode = Mode.actionSelect;
    }

    private void Update()
    {
        if (mode == Mode.enemySelect && target.CompareTag("Enemy"))
        {
            // Use action on target
            activePlayer.GetComponent<ActorSuper>().skills[skillSelection].SkillAction(target);

            // Remove energy cost
            float energyCost = activePlayer.GetComponent<ActorSuper>().skills[skillSelection].energyCost;
            activePlayer.GetComponent<ActorSuper>().UseEnergy(energyCost);

            NextPlayer();
        }
    }

    public void SetTarget(GameObject selected)
    {
        target = selected;
        //Debug.Log("Target: " + target.GetComponent<ActorSuper>().charName);
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

    // Decide which action to take
    public void ActionButton()
    {
        actionSelect.SetActive(false);
        skillSelect.SetActive(true);
    }

    // Skill buttons pressed. Save skill selected. Switch to select enemy
    public void SkillSelection(int skillNum)
    {
        skillSelect.SetActive(false);
        skillSelection = skillNum;

        // Clear target?
        target = gameObject;
        mode = Mode.enemySelect;
    }

    // Requeues the current player, pops queue to get next one, calls enemy logic until a player is found
    public void NextPlayer()
    {
        queue.Enqueue(activePlayer);
        activePlayer = queue.Dequeue();
        Debug.Log(activePlayer.GetComponent<ActorSuper>().charName + "'s turn.");

        if (activePlayer.CompareTag("Enemy"))
            mode = Mode.enemyTurn;

        while (activePlayer.CompareTag("Enemy"))
        {
            EnemyAction();

            queue.Enqueue(activePlayer);
            activePlayer = queue.Dequeue();
            Debug.Log(activePlayer.GetComponent<ActorSuper>().charName + "'s turn.");
        }

        actionSelect.SetActive(true);
        mode = Mode.actionSelect;
    }

    // All combat decisions for the enemy to attack the player
    private void EnemyAction()
    {
        activePlayer.GetComponent<ActorSuper>().skills[0].SkillAction(gm.party[0]);
    }
}
