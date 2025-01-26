using UnityEngine;
using UnityEngine.InputSystem;

public class HandshakeGame : MonoBehaviour
{
    [SerializeField]
    private HandScript m_Player1;
    [SerializeField]
    private HandScript m_Player2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputActionMap playerMap1 = GameManager.Instance.GetPlayerInput(0).actions.FindActionMap("Player");
        playerMap1.FindAction("BasicAction").performed += m_Player1.openHandShake;
        playerMap1.FindAction("BasicAction").canceled += m_Player1.changeFlag;

        InputActionMap playerMap2 = GameManager.Instance.GetPlayerInput(1).actions.FindActionMap("Player");
        playerMap2.FindAction("BasicAction").performed += m_Player2.openHandShake;
        playerMap2.FindAction("BasicAction").canceled += m_Player2.changeFlag;
    }
}
