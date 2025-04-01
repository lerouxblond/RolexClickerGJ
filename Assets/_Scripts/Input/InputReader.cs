using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
public class InputReader : ScriptableObject, PlayerInput.IPlayerActions
{
    private PlayerInput playerInput;

    public UnityAction OnClickEvent;


    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();
            playerInput.Player.SetCallbacks(this);
        }
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.started)
            OnClickEvent?.Invoke();
    }
}
