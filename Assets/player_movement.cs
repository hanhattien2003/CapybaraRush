using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
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
        // Lấy đầu vào từ người dùng
        movement.x = Input.GetAxisRaw("Horizontal");

        // Cập nhật tham số cho Animator (nếu có)
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        // Xử lý nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            isGrounded = false; // Chỉ cho phép nhảy khi đang trên mặt đất
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

