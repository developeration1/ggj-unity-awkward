using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public Color playerColor;

    [SerializeField] private Image box;
    [SerializeField] private Image button;
    [SerializeField] private Image buttonPressed;
    [SerializeField] private Image joystick;
    [SerializeField] private Image joystickLeft;
    [SerializeField] private Image joystickRight;

    private Coroutine gameStartCoroutine;
    private bool ButtonIsPressed => buttonPressed.enabled;

    private void Start()
    {
        box.enabled = true;
        box.color = playerColor;
        button.enabled = true;
        buttonPressed.enabled = false;
        buttonPressed.color = ColorManager.Instance.Palette.Button;
        joystick.enabled = true;
        joystickLeft.enabled = false;
        joystickLeft.color = ColorManager.Instance.Palette.Left;
        joystickRight.enabled = false;
        joystickRight.color = ColorManager.Instance.Palette.Right;
    }

    public void PressButton(InputAction.CallbackContext ctx)
    {
        button.enabled = false;
        buttonPressed.enabled = true;
        if (PlayerInputManager.instance.maxPlayerCount > 1)
        {
            if (GameManager.Instance.PlayerCount > 1)
            {
                Joystick[] joysticks = FindObjectsByType<Joystick>(FindObjectsSortMode.None);
                bool arePressed = true;
                foreach (Joystick joystick in joysticks)
                {
                    if (!joystick.ButtonIsPressed)
                    {
                        arePressed = false;
                    }
                }
                if (arePressed)
                    gameStartCoroutine = StartCoroutine("GameStartRoutine");
            }

            return;
        }
        gameStartCoroutine = StartCoroutine("GameStartRoutine");
    }

    public void UnpressButton(InputAction.CallbackContext ctx)
    {
        button.enabled = true;
        buttonPressed.enabled = false;
        if (gameStartCoroutine != null)
        {
            StopCoroutine(gameStartCoroutine);
            gameStartCoroutine = null;
        }

    }

    public void JoystickNeutral(InputAction.CallbackContext ctx)
    {
        joystickLeft.enabled = false;
        joystickRight.enabled = false;
        joystick.enabled = true;
    }

    public void JoystickMove(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() > 0)
        {
            joystickLeft.enabled = false;
            joystickRight.enabled = true;
            joystick.enabled = false;
        }
        else if (ctx.ReadValue<float>() < 0)
        {
            joystickLeft.enabled = true;
            joystickRight.enabled = false;
            joystick.enabled = false;
        }
    }

    private IEnumerator GameStartRoutine()
    {
        yield return new WaitForSeconds(3);
        bool a = Doozy.Runtime.Signals.Signal.Send(Doozy.Runtime.Signals.SignalStream.Get("Management", "GameStart"), PlayerPrefs.GetInt("firstGame", 1) == 1);
        print(a);
    }
}