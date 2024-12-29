using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Giá trị sức khỏe mà collectible sẽ cấp cho người chơi
    [SerializeField] private float healthValue;

    // Khi có vật thể va chạm với collider của HealthCollectible
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Gọi phương thức AddHealth trên player_health để cộng thêm sức khỏe
            collider.GetComponent<player_health>().AddHealth(healthValue);
            
            // Ẩn đối tượng này đi sau khi được thu thập
            gameObject.SetActive(false);
        }
    }
}
