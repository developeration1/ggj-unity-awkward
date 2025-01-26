using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform parent;

    private void Start()
    {
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            GameObject go = Instantiate(playerPrefab);
            if (parent)
                go.transform.SetParent(parent);
            Joystick joystick = go.GetComponent<Joystick>();
            joystick.playerColor = GameManager.Instance.PlayerCount > 1 ? ColorManager.Instance.Palette.Player2 : ColorManager.Instance.Palette.Player1;
            InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
            playerMap.FindAction("BasicAction").performed += joystick.PressButton;
            playerMap.FindAction("BasicAction").canceled += joystick.UnpressButton;
            playerMap.FindAction("DirectionAction").performed += joystick.JoystickMove;
            playerMap.FindAction("DirectionAction").canceled += joystick.JoystickNeutral;
        });
    }
}
