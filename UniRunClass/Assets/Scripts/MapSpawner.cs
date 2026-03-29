using UnityEngine;

public class MapSpawner : MonoBehaviour
{

    public GameObject[] prefabs;

    public bool isGameOver;

    public float maxSpawnTime = 2.5f;
    private float spawnTime = 0f;
    private int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;


        spawnTime += Time.deltaTime;

        if (spawnTime > maxSpawnTime)
        {
            spawnTime = 0f;

            currentIndex = (int)Mathf.Repeat(currentIndex + 1, prefabs.Length);

            GameObject obj = Instantiate(prefabs[currentIndex], transform.position, transform.rotation);
            
            /*
             쿠키런은 아이템도 고정이니까 다음에 쓰자

            if(Random.value < 0.8f)
            {
                GameObject targetItem = null;

                // 오브젝트 내 모든 하위 오브젝트 조사
                // 계층이나 상속구조도 transform 정보에 포함 되어있기 때문
                foreach (Transform child in obj.transform)
                {
                    if (child.CompareTag("item"))
                    {
                        targetItem = child.gameObject;
                        break; 
                    }
                }

                targetItem.SetActive(true);
            }
            */
            Destroy(obj, 8f);

        }
    }
}
