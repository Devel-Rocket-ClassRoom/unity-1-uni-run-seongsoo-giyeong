using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public bool isStop = false;

    private GameManager gameManager;
    private float speed;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        speed = gameManager.speed;
        isStop = gameManager.isGameover;

        if (isStop) return;

        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
