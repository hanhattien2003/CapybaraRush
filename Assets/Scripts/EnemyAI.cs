using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkSpeed = 2f; // Tốc độ di chuyển thông thường
    public float chaseSpeed = 3f; // Tốc độ khi đuổi theo
    public Transform leftBoundary; // Điểm giới hạn bên trái
    public Transform rightBoundary; // Điểm giới hạn bên phải
    public float chaseRange = 5f; // Phạm vi phát hiện Player

    private Transform player; // Tham chiếu đến Player
    private bool movingRight = true; // Hướng di chuyển ban đầu
    private Animator animator; // Tham chiếu đến Animator

    private float currentSpeed; // Tốc độ hiện tại của Enemy

    public player_health playerHealth; // Tham chiếu đến script player_health
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
    currentSpeed = walkSpeed; // Đặt tốc độ di chuyển thông thường

    if (movingRight)
    {
        transform.position += Vector3.right * currentSpeed * Time.deltaTime;

        // Kiểm tra nếu đã chạm tới ranh giới phải
        if (transform.position.x >= rightBoundary.position.x)
        {
            movingRight = false;
            Flip();
        }

        // Đảm bảo hướng di chuyển và hướng hình ảnh đồng bộ
        if (transform.localScale.x < 0)
        {
            Flip();
        }
    }
    else
    {
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        // Kiểm tra nếu đã chạm tới ranh giới trái
        if (transform.position.x <= leftBoundary.position.x)
        {
            movingRight = true;
            Flip();
        }

        // Đảm bảo hướng di chuyển và hướng hình ảnh đồng bộ
        if (transform.localScale.x > 0)
        {
            Flip();
        }
    }
}


   private void ChasePlayer()
{
    currentSpeed = chaseSpeed; // Đặt tốc độ khi đuổi theo

    // Chỉ di chuyển theo trục x (ngang), giữ nguyên vị trí y (dọc)
    Vector3 direction = (player.position - transform.position).normalized;
    Vector3 newPosition = transform.position;

    newPosition.x += direction.x * currentSpeed * Time.deltaTime; // Chỉ thay đổi vị trí x
    transform.position = newPosition;

    // Kiểm tra và lật hình chỉ khi hướng di chuyển thay đổi
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

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Kiểm tra xem đối tượng va chạm có phải là Player không
        if (collider.CompareTag("Player"))
        {
            // Đảm bảo playerHealth không null
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f); // Gây sát thương 1 đơn vị
            }
            else
            {
                Debug.LogError("playerHealth is not assigned in EnemiesDamage!");
            }
        }
    }

}
