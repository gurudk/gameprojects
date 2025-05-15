using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int gamescore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnGUI()
    {
        GUI.skin.box.fontSize = 30;
        GUI.Box(new Rect(20, 20, 200, 50), "Score " + gamescore);
        GUI.Box(new Rect(Screen.width - 220, 20, 200, 50), "Level " + GameState.level);
        if (GameState.state == GameState.gameOver)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "Game Over~");
        }

        if (GameState.state == GameState.levelComplete)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "Level Complete");

        }

        if (GameState.state == GameState.Success)
        {
            GUI.skin.box.fontSize = 40;
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "Congratulations～");

        }
    }
}
