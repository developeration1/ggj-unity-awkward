using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventControler2Players : MonoBehaviour
{
    [SerializeField]
    private HandScript m_Player1;
    [SerializeField]
    private HandScript m_Player2;
    [SerializeField]
    private GameObject m_message;
    [SerializeField]
    private GameObject m_messageFail;
    [SerializeField]
    private MMF_Player m_player;
    

    private bool playerActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            if (!playerActive)
            {
                playerActive = true;
                InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
                playerMap.FindAction("BasicAction").performed += m_Player1.openHandShake;
                playerMap.FindAction("BasicAction").canceled += m_Player1.changeFlag;
            }
            else
            {
                InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
                playerMap.FindAction("BasicAction").performed += m_Player2.openHandShake;
                playerMap.FindAction("BasicAction").canceled += m_Player2.changeFlag;
            }
        });
    }

    public void winHand()
    {
        m_message.SetActive(true);
        m_player.PlayFeedbacks();
    }
    public void loseHand()
    {
        m_messageFail.SetActive(true);
        m_player.PlayFeedbacks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
