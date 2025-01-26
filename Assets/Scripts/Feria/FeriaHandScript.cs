using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class FeriaHandScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject m_message;
    [SerializeField]
    private GameObject m_messageFail;
    [SerializeField]
    private MMF_Player m_player;
    [SerializeField]
    private FeriaMoneySpawner m_feriaSpawner;
    private bool m_endGame = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
            playerMap.FindAction("BasicAction").performed += this.takeChange;
        });
    }

    private void takeChange(InputAction.CallbackContext ctx)
    {
        animator.SetBool("Pressed", true);
        //VALIDAR SI HAY CAMBIO DE MÁS
        if (m_feriaSpawner.isMoreMoney())
        {
            failGame();
        }
        else
        {
            winGame();
        }
    }

    public void ReturnChange()
    {
        animator.SetBool("Return", true);
        //VALIDAR SI EL CAMBIO ESTÁ BIEN
        if (m_feriaSpawner.isMoreMoney())
        {
            winGame();
        }
        else
        {
            failGame();
        }
    }

    private void failGame()
    {
        if (!m_endGame)
        {
            m_messageFail.SetActive(true);
            m_player.PlayFeedbacks();
            m_endGame = true;
        }
    }
    private void winGame()
    {
        if (!m_endGame)
        {
            m_message.SetActive(true);
            m_player.PlayFeedbacks();
            m_endGame = true;
        }
    }
}
