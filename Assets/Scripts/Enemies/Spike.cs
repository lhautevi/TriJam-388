using UnityEngine;

public class Spike : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.OnPlayerDied();
            }
        }
    }
}
