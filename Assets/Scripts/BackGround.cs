using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCam; // Tham chiếu tới Camera chính
    public Transform MidBG;  // Tham chiếu tới background ở giữa
    public Transform SideBG; // Tham chiếu tới background bên cạnh
    public float length;     // Chiều dài của background

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra vị trí camera và cập nhật vị trí background
        if (mainCam.position.x > MidBG.position.x)
        {
            UpdateBackgroundPosition(Vector3.right);
        }
        else if (mainCam.position.x < MidBG.position.x)
        {
            UpdateBackgroundPosition(Vector3.left);
        }
    }

    void UpdateBackgroundPosition(Vector3 direction)
    {
        // Cập nhật vị trí SideBG để tiếp tục với MidBG
        SideBG.position = MidBG.position + direction * length;

        // Hoán đổi MidBG và SideBG
        Transform temp = MidBG;
        MidBG = SideBG;
        SideBG = temp;
    }
}
