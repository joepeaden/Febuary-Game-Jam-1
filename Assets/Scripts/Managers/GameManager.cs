using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] party;
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;

        party = new GameObject[1];
        party[0] = Instantiate((GameObject)Resources.Load("Prefabs/Actors/Party/Healer"));

        DontDestroyOnLoad(gameObject);
    }

    public void EnterLevel()
    {
        SceneManager.LoadScene("Scenes/LevelTest");
    }

    public void EnterCombat()
    {
        SceneManager.LoadScene("Scenes/CombatTesting");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
