using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    [SerializeField] private float startingHealth; // Máu khởi đầu
    public float currentHealth { get; private set; } // Máu hiện tại

    public GameManager gameManager; // Tham chiếu đến GameManager

    private bool isDead; // Kiểm tra trạng thái sống/chết

    public void Awake()
    {
        currentHealth = startingHealth; // Khởi tạo máu ban đầu
        isDead = false; // Đảm bảo trạng thái là sống khi bắt đầu
    }

    private void TakeDamage(float _damage)
    {
        // Giảm máu và đảm bảo giá trị không nhỏ hơn 0
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // Kiểm tra máu
        if (currentHealth > 0 && !isDead)
        {
            // Nhân vật còn sống
            Debug.Log($"Player took {_damage} damage. Current health: {currentHealth}");
        }
        else if (!isDead)
        {
            // Nếu chết, gọi hàm Die
            Die();
        }
    }

    private void Die()
{
    isDead = true;
    Debug.Log("Player is dead!");  // Kiểm tra xem hàm Die có được gọi hay không
    
    // Kiểm tra nếu gameManager không null và gọi GameOver()
    if (gameManager != null)
    {
        Debug.Log("Calling GameOver from player_health");  // Kiểm tra nếu GameOver được gọi
        gameManager.GameOver();
    }
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
