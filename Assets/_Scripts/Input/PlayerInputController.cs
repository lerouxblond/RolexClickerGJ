using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public InputReader Input;

    private void OnEnable()
    {
        Input.OnExitGameEvent += OnExitGame;
    }

    private void OnDisable()
    {
        Input.OnExitGameEvent -= OnExitGame;
    }

    private void OnExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
