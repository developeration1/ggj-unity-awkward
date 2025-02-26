using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Sprite[] m_SpriteArray;
    [SerializeField]
    private float m_Speed = .2f;
    [SerializeField]
    private int m_endtime = 5;

    [SerializeField] private MMF_Player m_player;
    //[SerializeField] private AudioSource m_audio;
    private int m_IndexSprite;
    private bool IsDone;
    private bool m_animationEnd = false;
    private bool m_animationStart = false;
    private Coroutine m_CorotineAnim;
    private void Start()
    {
        IsDone = true;
        StopCoroutine(Func_PlayAnimUI());
    }

    private void Update()
    {
        if (!m_animationStart)
        {

            m_player.PlayFeedbacks();
            ((MMF_PositionShake)m_player.FeedbacksList[0]).ShakeSpeed = 15 * Time.time;
            if (m_endtime <= Time.time)
            {
                gameObject.GetComponent<AudioSource>().Play();
                IsDone = false;
                StartCoroutine(Func_PlayAnimUI());
            }
        }
    }

     public bool is_endAnimation()
    {
        return m_animationEnd;
    }

    IEnumerator Func_PlayAnimUI()
    {
        m_animationStart = true;
        
        yield return new WaitForSeconds(m_Speed);
        
        if (m_IndexSprite < m_SpriteArray.Length)
        {
            m_Image.sprite = m_SpriteArray[m_IndexSprite];
            m_IndexSprite += 1;

            if (IsDone == false)
                m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
        }
        else
        {
            
            m_animationEnd = true;
        }
    }
}