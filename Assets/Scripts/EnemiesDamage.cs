using UnityEngine;

public class EnemiesDamage : MonoBehaviour
{
    public player_health playerHealth; // Tham chiếu đến script player_health

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
