using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float moveSpeed = 8f; // Tốc độ di chuyển
    public float jumpForce = 5f; // Lực nhảy
    public Rigidbody2D rb;      // Tham chiếu đến Rigidbody2D
    public Animator animator;   // Tham chiếu đến Animator để xử lý hoạt ảnh

    private Vector2 movement;   // Vector để lưu hướng di chuyển
    private bool isGrounded;    // Kiểm tra nhân vật có trên mặt đất không

    void Awake()
    {
        // Tự động tìm Rigidbody2D khi script được khởi tạo
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
{
    movement.x = Input.GetAxisRaw("Horizontal");

    if (animator != null)
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Horizontal", movement.sqrMagnitude);
    }

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }

    // Lật sprite khi di chuyển
    if (movement.x != 0)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = movement.x >0; // Lật sprite nếu di chuyển sang trái
    }
}



    void FixedUpdate()
    {
        // Di chuyển nhân vật
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu nhân vật chạm đất
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Đã chạm đất");
        }
    }
}

