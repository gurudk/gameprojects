using UnityEngine;
using UnityEngine.SceneManagement;

public class donut : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float levelCompleteTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        levelCompleteTimer = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.levelComplete || GameState.state == GameState.Success)
        {
            rigidBody.linearVelocity = Vector2.zero;
            levelCompleteTimer -= Time.deltaTime;

            if (levelCompleteTimer <= 0.0f)

            {
                if (GameState.level == 1)
                {
                    GameState.level = 2;
                    SceneManager.LoadScene("Scenes/Level 2");
                }
                else if (GameState.level == 2)
                {
                    GameState.level = 3;
                    SceneManager.LoadScene("Scenes/Level 3");
                }
                else if (GameState.level == 3)
                {
                    GameState.level = 4;
                    SceneManager.LoadScene("Scenes/Level 4");
                }
                else if (GameState.level == 4)
                {
                    GameState.level = 5;
                    SceneManager.LoadScene("Scenes/Level 5");
                }
                else
                {
                    if (GameState.level == 5)
                    {
                        GameState.state = GameState.Success;
                    }
                    else
                    {
                        GameState.state = GameState.levelComplete;
                    }
                }
            }
        }

        if (GameState.state == GameState.gamePlay)
        {
            if (transform.position.y < -10.0f)
            {
                GameState.state = GameState.gameOver;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WoodPlank")
        {
            Scoring.gamescore += 10;
        }
        else if (collision.gameObject.name == "Sphere")
        {
            Scoring.gamescore += 50;
        }
        else if (collision.gameObject.name == "DonutBox")
        {
            Scoring.gamescore += 100;

            if (GameState.level == 5)
            {
                GameState.state = GameState.Success;
            }
            else
            {
                GameState.state = GameState.levelComplete;
            }
        }
    }
}
