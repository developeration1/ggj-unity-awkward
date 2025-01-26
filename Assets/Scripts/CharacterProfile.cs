using UnityEngine;

[CreateAssetMenu(fileName = "CharacterProfile", menuName = "Scriptable Objects/CharacterProfile")]
public class CharacterProfile : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private Sprite profile;
    [SerializeField] private Sprite full;
    [SerializeField] private Sprite front;
    [SerializeField] private Sprite back;
    [SerializeField] private bool unlocked;

    public string CharacterName => characterName;
    public Sprite Profile => profile;
    public Sprite Full => full;
    public Sprite Front => front;
    public Sprite Back => back;
    public bool Unlocked => unlocked;
}
