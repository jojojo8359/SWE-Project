using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CannonScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float startTimeBetween;
    public float cannonMoveDelay = 1.0f;
    public TMP_Text bValueText;
    public GameObject explosionSprite;
    private Shake shake;

    private float timeBetween;
    private float A = 1.0f;
    private float B;
    public float speed = -20f;

    void Start()
    {
        timeBetween = startTimeBetween;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    public void SetParameters(float a)
    {
        A = a;
    }

    public void OnFireButtonClick()
    {
        if (timeBetween <= 0)
        {
            // Instantiate the bullet at the firepoint position and rotation
            GameObject newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation);
            explosionSprite.SetActive(true);
            shake.CamShake();
            AudioManager.Instance.PlayButtonPressSound();

            // Access the BulletScript component of the instantiated bullet
            BulletScript bulletScript = newBullet.GetComponent<BulletScript>();

            // Set the parameters A and B
            if (bulletScript != null)
            {
                bulletScript.SetParameter(A, speed);
            }

            StartCoroutine(MoveCannonWithDelay());

            // Reset the time between shots to start the cooldown
            timeBetween = startTimeBetween;
        }
        else
        {
            Debug.Log("Cannon is on cooldown!");
        }
    }

    IEnumerator MoveCannonWithDelay()
    {
        B = Mathf.RoundToInt(Random.Range(-5f, 9f));
        yield return new WaitForSeconds(cannonMoveDelay);

        // Move the Cannon object on the y-axis based on the value of B
        transform.position = new Vector3(transform.position.x, B, transform.position.z);
        explosionSprite.SetActive(false);

        // Update the text with the current value of B after the movement
        UpdateBValueText();
    }

    void UpdateBValueText()
    {
        if (bValueText != null)
        {
            bValueText.text = B.ToString();
        }
    }

    void Update()
    {
        timeBetween -= Time.deltaTime;
    }
}









