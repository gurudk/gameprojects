using UnityEngine;

public class Woodplank : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.gamePlay)
        {
            if (Input.GetKey("w")) transform.Translate(0, 3 * Time.deltaTime, 0);

            if (Input.GetKey("s")) transform.Translate(0, -3 * Time.deltaTime, 0);

            if (Input.GetKey("left")) transform.Translate(-3 * Time.deltaTime, 0, 0);

            if (Input.GetKey("right")) transform.Translate(3 * Time.deltaTime, 0, 0);

            if (Input.GetKey("up")) transform.Rotate(0, 0, 40 * Time.deltaTime);
            if (Input.GetKey("down")) transform.Rotate(0, 0, -40 * Time.deltaTime);
        }
    }
}
