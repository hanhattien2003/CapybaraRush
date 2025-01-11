using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daRoi = false;
    public Transform diemKhoiPhuc;
    public player_health playerHealth;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("KhoiPhuc", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
             playerHealth.TakeDamage(1f);
        }
        
    }
    void KhoiPhuc()
    {
        rb.isKinematic = true;
        rb.linearVelocity = Vector2.zero;
        rb.angularDamping = 0;
        transform.position = diemKhoiPhuc.position;
        daRoi = false;
    }
}
