using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed = 5f;
    public bool isStop = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        isStop = gameManager.isGameover;

        if (isStop) return;

        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
