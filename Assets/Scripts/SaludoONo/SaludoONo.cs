using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SaludoONo : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Animator animatorFromRandomGuy;

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
            playerMap.FindAction("BasicAction").performed += this.Wave;
            playerMap.FindAction("BasicAction").canceled += this.Unwave;
        });
    }

    private void Wave(InputAction.CallbackContext ctx)
    {
        animator.SetBool("Pressed", true);
    }

    private void Unwave(InputAction.CallbackContext ctx)
    {
        animator.SetBool("Pressed", false);
    }

    public void End()
    {
        if (!animatorFromRandomGuy.GetBool("Wave") && animator.GetBool("Pressed")) {
            animator.SetBool("Win", true);
        } else {
            animator.SetBool("Lost", true);
        }

        StartCoroutine(ResetBool());
    }

    private IEnumerator ResetBool()
    {
        yield return null;
        animator.SetBool("Win", false);
        animator.SetBool("Lost", false);
    }
}
