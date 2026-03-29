using System.Net.NetworkInformation;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Slider Hp;
    
    public PlayerController player;
    public MapSpawner spawner;

    public GameObject gameOverUi;

    public bool isGameover;

    private int score = 0;
    public float health = 100f;
    public float speed = 7f;

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
            Hp.value = health / 100f;

            isGameover = true;
            player.Die();
            spawner.isGameOver = true;

            gameOverUi.SetActive(true);
            return;
        }

        Hp.value = health / 100f;

        hpDecreaseTime += Time.deltaTime;
        if(hpDecreaseTime > 1 && !player.isImmune)
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

    }
}
