using UnityEngine;

public class Item : MonoBehaviour
{
    public int score = 1;

    private GameManager manager;

    private void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Player") && gameObject.CompareTag("Coin")) 
        {
            manager.AddScore(score);
            Destroy(gameObject);

        }
        else if(collision.CompareTag("Player") && gameObject.CompareTag("item"))
        {
            collision.gameObject.GetComponent<PlayerController>().isImmune = true;
            Destroy(gameObject);
        }
    }
}
