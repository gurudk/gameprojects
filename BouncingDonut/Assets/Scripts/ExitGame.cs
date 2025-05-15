using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        // 检测是否按下了 ESC 键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 调用退出游戏的函数
            QuitGame();
        }

    }

    void QuitGame()
    {
        // 如果在编辑器中运行
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // 如果是打包后的应用程序
#else
            Application.Quit();
#endif
    }
}
