using System.Collections;
using Doozy.Runtime.UIManager.Animators;
using Doozy.Runtime.UIManager.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonCharacterHolder : CharacterHolder
{
    [SerializeField] private TMP_Text textViewP1;
    [SerializeField] private Image fullCharacterViewP1;
    [SerializeField] private TMP_Text textViewP2;
    [SerializeField] private Image fullCharacterViewP2;
    [SerializeField] private Image profileCharacterView;

    private UISelectableColorAnimator animator;
    private UIButton uiButton;
    public bool nextPlayer = false;
    
    public CharacterUnlockManager characterUnlockManager;


    public void Start()
    {
        animator = GetComponent<UISelectableColorAnimator>();
        animator.highlightedAnimation.customStartValue = ColorManager.Instance.Palette.Player1;
        uiButton = GetComponent<UIButton>();
        textViewP1.color = ColorManager.Instance.Palette.Player1;
        fullCharacterViewP1.color = ColorManager.Instance.Palette.Player1;
        if (textViewP2 && fullCharacterViewP2)
        {
            textViewP2.color = ColorManager.Instance.Palette.Player2;
            fullCharacterViewP2.color = ColorManager.Instance.Palette.Player2;
        }
        profileCharacterView.sprite = characterInfo.Profile;

        if (!IsCharacterUnlocked())
        {
            uiButton.interactable = true;
        }
    }

    private bool IsCharacterUnlocked()
    {
        return characterUnlockManager.IsCharacterUnlocked(characterInfo.CharacterName);
    }

    public void Select()
    {
        if (nextPlayer)
        {
            textViewP2.text = characterInfo.CharacterName;
            fullCharacterViewP2.sprite = characterInfo.Full;
            return;
        }
        textViewP1.text = characterInfo.CharacterName;
        fullCharacterViewP1.sprite = characterInfo.Full;
    }

    public void Submit()
    {
        if (GameManager.Instance.PlayerCount > 1)
        {
            foreach (Transform child in transform.parent)
            {
                child.GetComponent<UISelectableColorAnimator>().selectedAnimation.customStartValue = ColorManager.Instance.Palette.Player2;
                child.GetComponent<UIButtonCharacterHolder>().nextPlayer = true;
            }
        }
        //Codigo para asignar a personaje
    }
}
