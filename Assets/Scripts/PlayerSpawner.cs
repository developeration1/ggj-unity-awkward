using System.Collections.Generic;
using Doozy.Runtime.Common.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform parent;

    private void OnEnable()
    {
        GameManager.Instance.ClearPlayers();
        parent.DestroyChildren();
    }

    private void Start()
    {
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            GameObject go = Instantiate(playerPrefab);
            if (parent)
                go.transform.SetParent(parent);
            GameManager.Instance.AddPlayer(playerInput);
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
