using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng là nhân vật
        if (other.CompareTag("Player"))
        {
            // Lấy component player_health từ nhân vật
            player_health playerHealth = other.GetComponent<player_health>();

            if (playerHealth != null)
            {
                // Gây sát thương khi rơi vào KillZone (ví dụ: 999 để chắc chắn chết)
                playerHealth.TakeDamage(1);
                Debug.Log("Player took damage from falling into KillZone!");
            }
            else
            {
                Debug.LogError("No player_health script found on the player!");
            }
        }
    }
}
