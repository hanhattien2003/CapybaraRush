using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum DifficultyLevel { Easy, Medium, Hard }
    private static DifficultyLevel currentDifficulty;

    // Hàm để thiết lập độ khó và lưu vào PlayerPrefs
    public static void SetDifficulty(DifficultyLevel difficulty)
    {
        currentDifficulty = difficulty;
        PlayerPrefs.SetInt("Difficulty", (int)currentDifficulty);  // Lưu độ khó vào PlayerPrefs
        PlayerPrefs.Save();  // Lưu ngay lập tức
        Debug.Log("Difficulty set to: " + currentDifficulty);
    }

    // Hàm lấy độ khó từ PlayerPrefs hoặc thiết lập độ khó mặc định nếu chưa có
    public static DifficultyLevel GetDifficulty()
    {
        // Nếu chưa có độ khó lưu trong PlayerPrefs, thì chọn Medium làm mặc định
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            currentDifficulty = (DifficultyLevel)PlayerPrefs.GetInt("Difficulty");
        }
        else
        {
            // Nếu chưa lưu, đặt độ khó là Medium mặc định
            currentDifficulty = DifficultyLevel.Medium;
        }

        return currentDifficulty;
    }
}
