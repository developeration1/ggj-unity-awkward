using UnityEngine;

[CreateAssetMenu(fileName = "GameColorPalette", menuName = "Scriptable Objects/GameColorPalette")]
public class GameColorPalette : ScriptableObject
{
    [SerializeField] private Color player1;
    [SerializeField] private Color player2;
    [SerializeField] private Color button;
    [SerializeField] private Color left;
    [SerializeField] private Color right;
    
    public Color Player1 => player1;
    public Color Player2 => player2;
    public Color Button => button;
    public Color Left => left;
    public Color Right => right;
}
