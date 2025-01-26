using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharacterUnlockManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    private List<Character> lockedCharacters = new List<Character>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        LoadCharacterStatuses();
        SetLockedCharacters();
    }

    private void LoadCharacterStatuses()
    {
        foreach (Character character in characterDatabase.characters)
        {
            string key = $"Character_{character.characterProfile.CharacterName}_Unlocked";

            if (PlayerPrefs.HasKey(key)) {
                print("Character key is set " + character.characterProfile.CharacterName + " " + PlayerPrefs.GetInt(key));
                character.isUnlocked = PlayerPrefs.GetInt(key) == 1;
            } else {
                print("Character key is not set " + character.characterProfile.CharacterName);
                PlayerPrefs.SetInt(key, character.isUnlocked ? 1 : 0);
            }
        }

        PlayerPrefs.Save();
    }

    private void SetLockedCharacters()
    {
        foreach (Character character in characterDatabase.characters)
        {
            string key = $"Character_{character.characterProfile.CharacterName}_Unlocked";

            if (PlayerPrefs.GetInt(key) == 0)
            {
                lockedCharacters.Add(character);
            }
        }
    }

    public void SaveUnlockedCharacter(string characterName)
    {
        string key = $"Character_{characterName}_Unlocked";
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }

    public bool IsCharacterUnlocked(string characterName)
    {
        return lockedCharacters.Find(x => x.characterProfile.CharacterName == characterName) != null;
    }

    public Character UnlockCharacter()
    {
        if (lockedCharacters.Count == 0) return null;

        int randomIndex = Random.Range(0, lockedCharacters.Count);
        Character randomCharacter = lockedCharacters[randomIndex];

        SaveUnlockedCharacter(randomCharacter.characterProfile.CharacterName);

        return randomCharacter;
    }
}
