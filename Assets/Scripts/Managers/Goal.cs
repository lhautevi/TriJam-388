using UnityEngine;

public class Goal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.OnPlayerWon();
        }
    }
}
