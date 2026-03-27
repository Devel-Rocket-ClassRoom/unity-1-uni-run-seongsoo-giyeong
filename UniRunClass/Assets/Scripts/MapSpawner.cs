using UnityEngine;

public class MapSpawner : MonoBehaviour
{

    public GameObject[] prefabs;

    public bool isGameOver;

    private float spawnTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;


        spawnTime += Time.deltaTime;

        if (spawnTime > 3)
        {
            spawnTime = 0f;

            int index = Random.Range(0, prefabs.Length);

            GameObject obj = Instantiate(prefabs[index], transform.position, transform.rotation);
            
            if(Random.value < 0.8f)
            {
                GameObject targetItem = null;

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

            Destroy(obj, 8f);

        }
    }
}
