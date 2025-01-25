using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class HandScript : MonoBehaviour
{

    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Sprite[] m_SpriteArray;

    private bool m_flagBottonPress = false;
    private int m_IndexSprite = 0;
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
            changeHand();
            print("listen");
        }
    }

    private void changeFlag(InputAction.CallbackContext ctx)
    {
        m_flagBottonPress = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeHand()
    {
        m_IndexSprite = (m_IndexSprite == 0) ? 1 : 0;
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
    }


}
