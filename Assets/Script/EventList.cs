using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventList : MonoBehaviour
{
    [SerializeField]
    private DoorScript m_doorL;
    [SerializeField]
    private DoorScript m_doorR;
    [SerializeField]
    private GameObject m_message;
    [SerializeField]
    private GameObject m_messageFail;
    [SerializeField] 
    private MMF_Player m_player;
    [SerializeField]
    private Timer m_timer;

    [SerializeField] private SceneChanger sc;
    
    private bool m_flagBottonPress = false;
    private bool m_endMessageFail = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
            print("Evento");
            //playerMap.FindAction("BasicAction").performed += this.DoorEvent;
            playerMap.FindAction("DirectionAction").performed += this.DoorEvent;
            //playerMap.FindAction("DirectionAction").canceled += this.changeFlag;
        });
    }

    private void DoorEvent(InputAction.CallbackContext ctx)
    {
        //print("Evento");
        //print(ctx.ReadValue<float>());
        float joystickValue = ctx.ReadValue<float>();
        if (!m_timer.is_endAnimation())
        {
            if (!m_flagBottonPress)
            {
                if (joystickValue < 0)
                {
                    m_flagBottonPress = true;
                    m_doorL.openDoor();
                    niceEvent();
                }
                else if (joystickValue > 0)
                {
                    m_flagBottonPress = true;
                    m_doorR.openDoor();
                    niceEvent();
                }

            }
        }
    }

    private void niceEvent()
    {
        m_message.SetActive(true);
        sc.ChangeScene();
        m_player.PlayFeedbacks();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_flagBottonPress)
        {
            if (!m_endMessageFail)
            {
                if (m_timer.is_endAnimation())
                {
                    m_messageFail.SetActive(true);
                    m_player.PlayFeedbacks();
                    m_endMessageFail = true;
                    sc.ChangeScene();
                }
            }
        }
    }
}
