using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    private void Start()
    {
        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            GameObject go = Instantiate(prefab);
            if (parent)
                go.transform.parent = parent;
            TestPlay tp = go.GetComponent<TestPlay>();
            InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
            playerMap.FindAction("BasicAction").performed += tp.TurnOn;
            playerMap.FindAction("BasicAction").canceled += tp.TurnOff;

        });
    }
}
