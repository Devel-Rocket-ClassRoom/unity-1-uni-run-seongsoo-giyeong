using UnityEngine;

public class Coin : Item
{
    private int coin = 1;
    private float energy = 0.5f;

    public override void Start()
    {
        base.Start();
        duration = 0f;
    }

    public override void ApplyEffect(GameObject player)
    {
        manager.AddScore(coin);
        player.GetComponent<PlayerController>().Heal(energy);
    }


    public override void RemoveEffect(GameObject player)
    {
        
    }
}
