using UnityEngine;
using UnityEngine.InputSystem;

public class FeriaHandScript : MonoBehaviour
{
    private Animator animator;

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
    }

    public void ReturnChange()
    {
        animator.SetBool("Return", true);
    }
}
