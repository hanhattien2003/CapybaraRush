using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkSpeed = 2f; // Tốc độ di chuyển thông thường
    public float chaseSpeed = 4f; // Tốc độ khi đuổi theo
    public Transform leftBoundary; // Điểm giới hạn bên trái
    public Transform rightBoundary; // Điểm giới hạn bên phải
    public float chaseRange = 5f; // Phạm vi phát hiện Player

    private Transform player; // Tham chiếu đến Player
    private bool movingRight = true; // Hướng di chuyển ban đầu
    private Animator animator; // Tham chiếu đến Animator

    private float currentSpeed; // Tốc độ hiện tại của Enemy

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentSpeed = walkSpeed; // Khởi tạo với tốc độ di chuyển thông thường
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            // Đuổi theo Player
            ChasePlayer();
        }
        else
        {
            // Di chuyển trái/phải
            Patrol();
        }
    }

    private void Patrol()
    {
        animator.SetBool("isWalking", true); // Kích hoạt Animation Walk
        currentSpeed = walkSpeed; // Đặt tốc độ di chuyển thông thường

        if (movingRight)
        {
            transform.position += Vector3.right * currentSpeed * Time.deltaTime;
            if (transform.position.x >= rightBoundary.position.x)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position += Vector3.left * currentSpeed * Time.deltaTime;
            if (transform.position.x <= leftBoundary.position.x)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    private void ChasePlayer()
{
    animator.SetBool("isWalking", true); // Kích hoạt Animation Walk
    currentSpeed = chaseSpeed; // Đặt tốc độ khi đuổi theo

    // Chỉ lấy hướng di chuyển theo trục X
    Vector3 direction = (player.position - transform.position).normalized;
    direction.y = 0; // Loại bỏ chiều Y để chỉ di chuyển theo chiều ngang

    transform.position += direction * currentSpeed * Time.deltaTime;

    // Lật Enemy theo hướng Player nếu cần
    if ((direction.x > 0 && transform.localScale.x < 0) || (direction.x < 0 && transform.localScale.x > 0))
    {
        Flip();
    }
}


    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
