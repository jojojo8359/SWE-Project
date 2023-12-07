using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float horizontalSpeed = -20f;
    private float A = 0.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate the initial vertical position
        float initialY = CalculateYPosition(transform.position.x);

        // Set the velocity with constant horizontal speed and calculated vertical component
        rb.velocity = new Vector2(horizontalSpeed, initialY);
    }

    // Method to set A and B values
    public void SetParameter(float a, float s)
    {
        A = (s < 0) ? a : -a; // Change the sign of A if horizontalSpeed is positive
        horizontalSpeed = s;
    }

    float CalculateYPosition(float x)
    {
        // Calculate y using the linear equation y = Ax + B
        return A * x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SideCollision"))
        {
            Destroy(this.gameObject);
        }
    }
}














