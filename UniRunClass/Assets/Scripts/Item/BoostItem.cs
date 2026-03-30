using UnityEngine;

public class BoostItem : Item
{
    public GameObject boost;

    private float originSpawnTime;
    private float originSpeed;
    public override void Start()
    {
        base.Start();
        duration = 3f;
    }
    public override void ApplyEffect(GameObject player)
    {
        // 자식 오브젝트 중에 부스트를 찾아서 활성화
        // 플레이어 컨트롤러에 메소드를 만들던가 할당을 하던가 해서 불러오기
        player.GetComponent<PlayerController>().isImmune = true;
        foreach (Transform effect in player.transform)
        {
            if (effect.name == "Boost")
            {
                boost = effect.gameObject;
                boost.SetActive(true);
            }
        }


        
        originSpawnTime = manager.spawner.maxSpawnTime;
        originSpeed = manager.speed;

        manager.spawner.maxSpawnTime /= 2;
        manager.speed *= 2;
        
        
    }



    public override void RemoveEffect(GameObject player)
    {
        player.GetComponent<PlayerController>().isImmune = false;
        boost.SetActive(false);
        manager.spawner.maxSpawnTime = originSpawnTime;
        manager.speed = originSpeed;
    }
}
