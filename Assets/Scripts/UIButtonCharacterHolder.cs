using Doozy.Runtime.UIManager.Animators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonCharacterHolder : CharacterHolder
{
    [SerializeField] private TMP_Text textView;
    [SerializeField] private Image fullCharacterView;
    [SerializeField] private Image profileCharacterView;

    private UISelectableColorAnimator animator;

    public void Start()
    {
        animator = GetComponent<UISelectableColorAnimator>();
        animator.highlightedAnimation.customStartValue = ColorManager.Instance.Palette.Player1;
        textView.color = ColorManager.Instance.Palette.Player1;
        fullCharacterView.color = ColorManager.Instance.Palette.Player1;
        profileCharacterView.sprite = characterInfo.Profile;
    }

    public void Select()
    {
        textView.text = characterInfo.CharacterName;
        fullCharacterView.sprite = characterInfo.Full;
    }
}
