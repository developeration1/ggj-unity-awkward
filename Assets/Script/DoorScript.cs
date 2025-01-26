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
        
    }

    public void DoorEvent(InputAction.CallbackContext ctx)
    {
        print("Evento");
        print(ctx.ReadValue<float>());
        float joystickValue = ctx.ReadValue<float>();
        if (!m_flagBottonPress)
        {
            if(joystickValue < 0)
            {
                m_flagBottonPress = true;
                openDoor();
            }
            else
            {

            }
            
        }
        //if (!m_flagBottonPress)
        //{
        //    m_flagBottonPress = true;
        //    openDoor();
        //}
    }

    private void changeFlag(InputAction.CallbackContext ctx)
    {
        m_flagBottonPress = false;
    }

    public void openDoor()
    {
        m_IndexSprite = (m_IndexSprite == 0) ? 1 : 0;
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
    }
}
