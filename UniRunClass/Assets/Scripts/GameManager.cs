using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public RectTransform Hp;

    public PlayerController player;
    public MapSpawner spawner;

    public GameObject gameOverUi;

    public bool isGameover;

    private int score = 0;
    public float health = 100f;

    private float hpDecreaseTime;

    public void Update()
    {
        if (isGameover && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("CookieRun");
        }

        if (health <= 0 || player.isDead)
        {
            health = 0;
            isGameover = true;
            player.Die();
            spawner.isGameOver = true;

            gameOverUi.SetActive(true);
            return;
        }

        Hp.localScale = new Vector3(health / 100, 1f, 1f);

        hpDecreaseTime += Time.deltaTime;
        if(hpDecreaseTime > 1)
        {
            hpDecreaseTime = 0;
            health -= 3;
        }



    }

    public void AddScore(int add)
    {
        score += add;
        health += 0.5f;
        scoreText.text = $"Coin : {score}";
    }

    public void Damage(float damage)
    {
        health -= damage;

        if(health < 0)
        {
            health = 0;
        }

        Hp.localScale = new Vector3(health/100, 1f, 1f);
    }
}
