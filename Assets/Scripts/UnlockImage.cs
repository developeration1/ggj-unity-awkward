using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class UnlockImage : MonoBehaviour
{
    public CharacterUnlockManager charUnlock;
    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(randomRoll());
    }

    private IEnumerator randomRoll()
    {
        for(int i = 0; i < 2; i++)
        {
            foreach (Character character in charUnlock.characterDatabase.characters)
            {
                image.sprite = character.characterProfile.Profile;
                yield return new WaitForSeconds(0.25f);
            }
        }

        Character randomCharacter = charUnlock.UnlockCharacter();
        image.sprite = randomCharacter.characterProfile.Profile;
    }
}
