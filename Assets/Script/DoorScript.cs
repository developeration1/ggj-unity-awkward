using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Sprite[] m_SpriteArray;
    private int m_IndexSprite = 0;
    private bool m_flagBottonPress = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
            playerMap.FindAction("BasicAction").performed += this.openHandShake;
            playerMap.FindAction("BasicAction").canceled += this.changeFlag;
        });
    }

    private void openHandShake(InputAction.CallbackContext ctx)
    {
        if (!m_flagBottonPress)
        {
            m_flagBottonPress = true;
            openDoor();
        }
    }

    private void changeFlag(InputAction.CallbackContext ctx)
    {
        m_flagBottonPress = false;
    }

    private void openDoor()
    {
        m_IndexSprite = (m_IndexSprite == 0) ? 1 : 0;
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
    }
}
