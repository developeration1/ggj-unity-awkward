using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProfile", menuName = "Scriptable Objects/PlayerProfile")]
public class CharacterProfile : ScriptableObject
{
    [SerializeField] private Sprite profile;
    [SerializeField] private Sprite full;
    [SerializeField] private Sprite front;
    [SerializeField] private Sprite back;

    public Sprite Profile => profile;
    public Sprite Full => full;
    public Sprite Front => front;
    public Sprite Back => back;
}
