using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_health : MonoBehaviour
{
    [SerializeField] public float startingHealth; // Máu khởi đầu
    public float currentHealth { get; private set; } // Máu hiện tại

    public GameManager gameManager; // Tham chiếu đến GameManager

    private bool isDead; // Kiểm tra trạng thái sống/chết

    public void Awake()
    {
        // Kiểm tra có dữ liệu máu trong PlayerPrefs không, nếu không thì set máu đầy
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            currentHealth = PlayerPrefs.GetFloat("PlayerHealth"); // Khôi phục số máu đã lưu
        }
        else
        {
            currentHealth = startingHealth; // Nếu không có thì sử dụng máu mặc định
        }

        isDead = false; // Đảm bảo trạng thái là sống khi bắt đầu
    }

    private void TakeDamage(float _damage)
    {
        // Giảm máu và đảm bảo giá trị không nhỏ hơn 0
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // Lưu lại số máu còn lại khi mất máu
        PlayerPrefs.SetFloat("PlayerHealth", currentHealth);

        if (currentHealth > 0)
        {
            // Nếu máu > 0, restart màn chơi mà không xóa dữ liệu máu
            RestartLevel();
        }
        else if (!isDead)
        {
            // Nếu máu <= 0, gọi hàm Die
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player is dead!");

        // Xóa dữ liệu máu khi chết, reset số máu để khi game restart sẽ bắt đầu với máu đầy
        PlayerPrefs.DeleteKey("PlayerHealth");

        if (gameManager != null)
        {
            Debug.Log("Calling GameOver from player_health");
            gameManager.GameOver();  // Hiển thị màn hình Game Over
        }
    }

    private void RestartLevel()
    {
        Debug.Log("Restarting Level");

        // Lưu lại số máu còn lại vào PlayerPrefs trước khi tải lại màn chơi
        PlayerPrefs.SetFloat("PlayerHealth", currentHealth);

        // Tải lại màn chơi
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
