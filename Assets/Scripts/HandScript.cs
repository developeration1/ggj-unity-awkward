using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class HandScript : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Sprite[] m_SpriteArray;
    [SerializeField]
    private PlayerInputManager playerImput;

    private bool m_flagBottonPress = false;
    private int m_IndexSprite = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Image.sprite = m_SpriteArray[m_IndexSprite];

    }

    public void openHandShake(InputAction.CallbackContext ctx)
    {
        if (!m_flagBottonPress)
        {
            m_flagBottonPress = true;
            changeHand();
        }
    }

    public void changeFlag(InputAction.CallbackContext ctx)
    {
        m_flagBottonPress = false;
    }

    private void changeHand()
    {
        m_IndexSprite = (m_IndexSprite == 0) ? 1 : 0;
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
    }


}
