using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public GameManager manager;
    
    protected float duration;
    public bool isActive;

    public virtual void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    public abstract void ApplyEffect(GameObject player);
    public abstract void RemoveEffect(GameObject player);

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerController>();
            player.AddItem(ApplyEffect, RemoveEffect, duration);
            Destroy(gameObject); // 아이템은 즉시 파괴
        }
    }

}
