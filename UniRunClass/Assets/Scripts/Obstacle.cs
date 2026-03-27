using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float damage = 10f;

    private GameManager manager;

    private void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if(collision.gameObject.GetComponent<PlayerController>().isImmune)
            {
                return;
            }


            manager.Damage(damage);
            Debug.Log("충돌");


        }
    }
}
