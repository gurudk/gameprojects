using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int state;
    public static int gamePlay = 1;
    public static int gameOver = 2;
    public static int levelComplete = 3;
    public static int Success = 4;
    public static int level = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = gamePlay;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


}
