using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameOverUI;
    public GameObject tryHaderUI;
    private bool isGameOver = false;

    public Enemy enemy;
    public GameObject enemyPleadUI;
    public GameObject enemyDeathUI;
    private bool hasPleaded = false;
    private bool hasSaidLastWords = false;

    void Start()
    {
    }

    void Update()
    {
        GameEnd();
        CheckEnemyText();
    }

    void GameEnd()
    {
        if (playerHealth.health <= 0 && isGameOver == false)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
        }
    }

    IEnumerator BeforeEnd()
    {
        playerHealth.healthText.text = "Health: 0";
        player.SetActive(false);
        tryHaderUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        tryHaderUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    void CheckEnemyText()
    {
        if (enemy.enemyHealth > 0 && enemy.enemyHealth <= 10 && hasPleaded == false)
        {
            hasPleaded = true;
            StartCoroutine(EnemyPleadCoroutine());
        }

        if (enemy.enemyHealth <= 0 && hasSaidLastWords == false)
        {
            hasSaidLastWords = true;
            StopAllCoroutines();
            StartCoroutine(EnemyDeathCoroutine());
        }
    }

    IEnumerator EnemyPleadCoroutine()
    {
        enemyPleadUI.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        enemyPleadUI.SetActive(false);
    }

    IEnumerator EnemyDeathCoroutine()
    {
        enemyPleadUI.SetActive(false);
        enemyDeathUI.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        enemyDeathUI.SetActive(false);
    }
}
