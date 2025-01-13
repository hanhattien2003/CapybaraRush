using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform mainCam;
    public Transform MidBg;
    public Transform SideBg;
    public float length;

    // Update is called once per frame
    void Update()
    {
         if (mainCam.position.x > MidBg.position.x) {
            UpdateBackgroundPosition (Vector3.right);
        }
        else if (mainCam.position.x < MidBg.position.x) {
            UpdateBackgroundPosition (Vector3.left);
        }
    }
    void UpdateBackgroundPosition(Vector3 direction) {
        SideBg.position = MidBg.position + direction * length;
        Transform temp = MidBg;
        MidBg = SideBg;
        SideBg = temp;
    }
}
