using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;
public class Obstacle : MonoBehaviour
{
    public float damage = 10f;

    private GameManager manager;
    private Animator animator;

    private void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if(collision.GetComponent<PlayerController>().isImmune)
            {
                Color myColor;
                ColorUtility.TryParseHtmlString("#FEC331", out myColor);

                GetComponent<SpriteRenderer>().color = myColor;
                animator.SetTrigger("Destroy");

                //Destroy(gameObject);

                return;
            }


            manager.Damage(damage);
            Debug.Log("충돌");


        }
    }
}
