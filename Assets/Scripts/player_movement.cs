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
    private bool isFacingLeft = true; // Biến kiểm tra hướng quay nhân vật (hướng mặc định là phải)

    public GameObject jumpSoundObject; // Object chứa âm thanh nhảy
    public GameObject runSoundObject;  // Object chứa âm thanh chạy

    private AudioSource jumpAudioSource; // AudioSource từ jumpSoundObject
    private AudioSource runAudioSource;  // AudioSource từ runSoundObject

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Lấy AudioSource từ các GameObject được gán
        if (jumpSoundObject != null)
        {
            jumpAudioSource = jumpSoundObject.GetComponent<AudioSource>();
        }

        if (runSoundObject != null)
        {
            runAudioSource = runSoundObject.GetComponent<AudioSource>();
            runAudioSource.loop = true; // Bật chế độ lặp để âm thanh chạy liên tục
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Cập nhật tốc độ di chuyển
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Phát âm thanh khi di chuyển
        if (Mathf.Abs(horizontalInput) > 0.1f && isGrounded)
        {
            if (runAudioSource != null && !runAudioSource.isPlaying)
            {
                runAudioSource.Play(); // Phát âm thanh chạy
            }
        }
        else
        {
            if (runAudioSource != null && runAudioSource.isPlaying)
            {
                runAudioSource.Stop(); // Dừng âm thanh khi không di chuyển
            }
        }

        // Quay đầu nhân vật khi di chuyển
        if (horizontalInput < 0 && !isFacingLeft)
        {
            Flip();
        }
        else if (horizontalInput > 0 && isFacingLeft)
        {
            Flip();
        }

        // Kiểm tra nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;

            if (jumpAudioSource != null)
            {
                jumpAudioSource.Play(); // Phát âm thanh nhảy
            }

            animator.SetBool("IsJumping", true);
        }

        if (!isGrounded)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
