using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float jumpForce = 5f; // Lực nhảy
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public Rigidbody2D rb;      // Tham chiếu đến Rigidbody2D
    private bool isGrounded;    // Kiểm tra nhân vật có trên mặt đất không
    public Animator animator;   // Tham chiếu đến Animator

    private float horizontalInput; // Input di chuyển ngang

    void Awake()
    {
        // Tự động tìm Rigidbody2D khi script được khởi tạo
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nhận đầu vào di chuyển ngang
        horizontalInput = Input.GetAxis("Horizontal");

        // Cập nhật tốc độ di chuyển
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Cập nhật giá trị Speed trong Animator (0 = đứng yên, >0 = chạy)
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Quay đầu nhân vật khi di chuyển bằng cách lật sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = horizontalInput > 0; // Lật sprite nếu di chuyển sang trái

        // Kiểm tra nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  // Thêm lực nhảy
            isGrounded = false; // Chỉ cho phép nhảy khi đang đứng trên mặt đất

            // Gọi animation nhảy
            animator.SetTrigger("Jump");
        }

        // Cập nhật trạng thái trong Animator
        if (!isGrounded)
        {
            // Nếu không chạm đất, chắc chắn animation "Jump" đang được phát
            animator.SetBool("IsJumping", true);
        }
        else
        {
            // Nếu nhân vật chạm đất, tắt trạng thái nhảy và điều chỉnh lại "Speed"
            animator.SetBool("IsJumping", false);
        }
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
