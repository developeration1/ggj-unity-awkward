using UnityEngine;

[System.Serializable]
public class Character
{
   public CharacterProfile characterProfile;
   public bool isUnlocked;
}

[CreateAssetMenu(fileName="CharacterDatabase", menuName="Scriptable Objects/Character Database")]
public class CharacterDatabase : ScriptableObject
{
   public Character[] characters;
}
