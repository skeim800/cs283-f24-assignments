using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Canvas startScreen;

    public Canvas gameScreen;
    public Canvas winScreen;
    public Canvas loseScreen;
    public Canvas startNarrative;
    public GameObject instructionScreen;

    public GameObject ratSpawner;
    public GameObject mage;
    public GameObject playerDead;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartOnClick);
        startScreen.enabled = true;
        startNarrative.enabled = false;
        instructionScreen.SetActive(false);
        gameScreen.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Spawner spawner = ratSpawner.GetComponent<Spawner>();
        EnemyBehavior enemyMage = mage.GetComponent<EnemyBehavior>();
        PlayerAttack player = playerDead.GetComponent<PlayerAttack>();
        if (enemyMage.defeated && !spawner.moreRats)
        {
            Win();
        }
        else if (player.playerDead)
        {
            GameOver();
        }
        if (Input.GetKey(KeyCode.S))
        {
            GameStart();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            instructionScreen.SetActive(!instructionScreen.activeSelf);
        }
    }

    public void StartOnClick()
    {
        startScreen.enabled = false;
        startNarrative.enabled = true;
    }

    public void GameStart()
    {
        startNarrative.enabled = false;
        gameScreen.enabled = true;
    }

    public void RestartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Win()
    {
        gameScreen.enabled = false;
        winScreen.enabled = true;
    }

    private void GameOver()
    {
        gameScreen.enabled = false;
        loseScreen.enabled = true;
    }
}
