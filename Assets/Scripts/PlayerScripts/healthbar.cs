using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
[SerializeField] private player_health playerHealth;
[SerializeField] private Image totalhealthBar;
[SerializeField] private Image currenthealthBar;
  
  private void Start(){
    totalhealthBar.fillAmount = playerHealth.startingHealth / 10;
  }
  private void Update(){
    currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
  }
}
