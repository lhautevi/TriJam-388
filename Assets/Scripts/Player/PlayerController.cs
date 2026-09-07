using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rigidbody;
    private RaycastHit2D _hit;

    public float speed;
    public float jumpForce;
    public bool isGrounded ;
    public float fallMultiplier= 2.5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Is grounded ?
        _hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
        if (_hit)
        {
            if (_hit.collider.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
        //deplacement
        float dir = Input.GetAxisRaw("Horizontal");
        rigidbody.linearVelocityX = dir * speed;

        //Saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidbody.linearVelocityY = jumpForce;
        }

        //Retombe
        if (!isGrounded && rigidbody.linearVelocityY < 0)
        {
            rigidbody.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
    }
}
