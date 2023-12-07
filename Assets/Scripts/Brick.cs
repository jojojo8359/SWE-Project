using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(BoxCollider2D))]
public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states = new Sprite[0];
    public int health { get; private set; }
    public int points = 100;
    public bool isSpecial;
    public GameOverScreen GameOverScreen;

    // Reference to the Scoring script
    private Scoring scoringScript;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Find and store a reference to the Scoring script in the scene
        scoringScript = FindObjectOfType<Scoring>();
    }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        gameObject.SetActive(true);
        health = states.Length;
        spriteRenderer.sprite = states[health - 1];
    }

    private void Hit()
    {
        health--;
        // Add point 
        if(isSpecial) {
            scoringScript.AddPoint(1000);
        } else {
            scoringScript.AddPoint(100);
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);

            if (isSpecial) {
                GameOver();
            }
        }
        else
        {
            spriteRenderer.sprite = states[health - 1];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Hit();
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup(true);
    }
}


