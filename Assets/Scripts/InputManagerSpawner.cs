using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerSpawner : MonoBehaviour
{
    [SerializeField] PlayerInputManager preConfiguredInputManager;
    public void SpawnInputManager()
    {
        if(PlayerInputManager.instance != null)
            Destroy(PlayerInputManager.instance.gameObject);
        Instantiate(preConfiguredInputManager);
    }
}
