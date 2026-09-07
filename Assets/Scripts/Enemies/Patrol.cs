using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(startPos.x + x, startPos.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnPlayerDied();
        }
    }
}
