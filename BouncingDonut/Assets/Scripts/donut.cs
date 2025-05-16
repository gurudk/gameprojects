using UnityEngine;
using UnityEngine.SceneManagement;

public class donut : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float levelCompleteTimer;
    float gameCompleteTimer;
    AudioSource boingA;
    AudioSource boingB;
    AudioSource boingC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        levelCompleteTimer = 1.0f;
        gameCompleteTimer = 5.0f;

        AudioSource[] audios = GetComponents<AudioSource>();
        boingA = audios[0];
        boingB = audios[1];
        boingC = audios[2];

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.levelComplete)
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
                else if (GameState.level == 5)
                {
                    GameState.level = 6;
                    SceneManager.LoadScene("Scenes/Level 6");
                }
                else
                {
                    if (GameState.level == 6)
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


        if (GameState.state == GameState.Success || GameState.state == GameState.gameOver)
        {
            rigidBody.linearVelocity = Vector2.zero;
            gameCompleteTimer -= Time.deltaTime;
            if (gameCompleteTimer < 0.0f)
            {
                GameState.level = 1;
                GameState.state = GameState.gamePlay;
                Scoring.gamescore = 0;
                SceneManager.LoadScene("Title");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WoodPlank")
        {
            Scoring.gamescore += 10;
            boingA.Play();
        }
        else if (collision.gameObject.name == "Sphere")
        {
            Scoring.gamescore += 50;
            boingB.Play();
        }
        else if (collision.gameObject.name == "DonutBox")
        {
            // 获取当前物体和对方的碰撞体
            Collider2D myCollider = collision.collider;
            Collider2D otherCollider = collision.otherCollider;

            // 忽略后续碰撞
            Physics2D.IgnoreCollision(myCollider, otherCollider, true);

            Scoring.gamescore += 100;
            boingC.Play();



            if (GameState.level == 6)
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
