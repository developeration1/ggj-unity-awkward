using UnityEngine;

[CreateAssetMenu(fileName="CharacterDatabase", menuName="Scriptable Objects/Character Database")]
public class CharacterDatabase : ScriptableObject
{
   public CharacterProfile[] characters;
}
