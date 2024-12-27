using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum DifficultyLevel { Easy, Medium, Hard }
    private static DifficultyLevel currentDifficulty = DifficultyLevel.Medium;

    public static void SetDifficulty(DifficultyLevel difficulty)
    {
        currentDifficulty = difficulty;
        Debug.Log("Difficulty set to: " + currentDifficulty);
    }

    public static DifficultyLevel GetDifficulty()
    {
        return currentDifficulty;
    }
}
