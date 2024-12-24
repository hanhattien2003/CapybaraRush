using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    public void Awake()
    {
        currentHealth = startingHealth; // Khởi tạo máu ban đầu
    }

    private void TakeDamage(float _damage)
    {
        // Giảm máu và đảm bảo giá trị không nhỏ hơn 0
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 ,startingHealth);

        // Kiểm tra máu
        if (currentHealth > 0)
        {
            // Nhân vật còn sống
            Debug.Log($"Player took {_damage} damage. Current health: {currentHealth}");
        }
        else
        {
            // Nhân vật chết
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        // Logic khi chết (ví dụ: reload scene, hiện menu game over, v.v.)
    }

    private void Update()
    {
        // Test: Nhấn phím E để gây sát thương 1 đơn vị
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1); // Gọi hàm TakeDamage để trừ 1 máu
        }
    }
}
