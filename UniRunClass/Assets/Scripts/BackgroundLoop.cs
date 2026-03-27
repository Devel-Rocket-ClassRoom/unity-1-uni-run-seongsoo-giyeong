using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
   public bool isStop = false;

    public float width;
    private void Update()
    {
        if (isStop) return;

        if(transform.position.x < -width)
        {
            transform.position += new Vector3(width * 2f, 0f, 0f);
        }
    }
}
