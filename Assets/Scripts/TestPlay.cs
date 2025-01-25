using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestPlay : MonoBehaviour
{
    [SerializeField] private Image signal;

    public void TurnOn(InputAction.CallbackContext ctx)
    {
        signal.color = Color.green;
    }

    public void TurnOff(InputAction.CallbackContext ctx)
    {
        signal.color = Color.white;
    }
}
