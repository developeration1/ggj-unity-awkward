using UnityEngine;

public class FeriaFrontHand : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AcceptReturn()
    {
        animator.SetBool("Return", true);
    }
}
