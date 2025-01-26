using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
public class HandScript : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Sprite[] m_SpriteArray;
    [SerializeField]
    private PlayerInputManager playerImput;
    [SerializeField]
    private Animator otherHandAnimator;

    private Animator myAnimator;

    private bool m_flagBottonPress = false;
    private int m_IndexSprite = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Image.sprite = m_SpriteArray[m_IndexSprite];

        myAnimator = GetComponent<Animator>();
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
        myAnimator.SetBool("IsFist", m_IndexSprite == 0);

        m_IndexSprite = (m_IndexSprite == 0) ? 1 : 0;
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
    }

    public void End()
    {
        if (otherHandAnimator.GetBool("IsFist") && myAnimator.GetBool("IsFist")) {
            myAnimator.SetBool("Match", true);
        } else if (!otherHandAnimator.GetBool("IsFist") && myAnimator.GetBool("IsFist")) {
            myAnimator.SetBool("Match", false);
        } else if (otherHandAnimator.GetBool("IsFist") && !myAnimator.GetBool("IsFist")) {
            myAnimator.SetBool("Match", false);
        } else {
            myAnimator.SetBool("Match", true);
        }

        myAnimator.SetBool("Ended", true);

        StartCoroutine(ResetBool());
    }

    private IEnumerator ResetBool()
    {
        yield return null;
        myAnimator.SetBool("Ended", false);
    }
}
