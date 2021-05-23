using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject introText;
    public GameObject playerTask1;
    public GameObject playerTask2;
    public GameObject gameOverText;

    public Transform Respawnpoint;
    public bool hasKey;

    //Gamemanager is a class which contains and manages background tasks for the game. fx, changing levels, background music, finding respawnpoints... etc...

    private void Awake()
    {  //Background music is attached to the this instance of gamemanager
        DontDestroyOnLoad(this.gameObject);//We dont want to destroy load this script everytime a scene is swithing
    }

    void Start()
    {
        Destroy(introText, 5f); //Destroy intro text after 3 seconds

        playerTask1.SetActive(false);
        playerTask2.SetActive(false);
        //We wanna update and check the spawnpoint frequently, since it changes every level
        InvokeRepeating("FindSpawnPoint", 0f, 5f);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Changing levelscene = levelscene + 1 - so we get to the next levelscene
    }

    //When task button is press than call these methods
    public void EnableTask1()
    {
        playerTask1.SetActive(true); //Button is pressed - activate task 1
        playerTask2.SetActive(true); //Button is pressed - activate task 2
    }
    public void EnableTask2()
    {
        playerTask2.SetActive(true); //Button is pressed - activate task 2
    }

    void FindSpawnPoint()
    {
        Respawnpoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        print("Found Point");
    }

    public void GameOver()
    {
        print("Game over!");
        gameOverText.SetActive(true);
    }

}

