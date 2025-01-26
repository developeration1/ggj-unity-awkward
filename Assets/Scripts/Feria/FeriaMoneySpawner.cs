using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class FeriaMoneySpawner : MonoBehaviour
{
    private int m_amount = 0;

    public List<CoinPrefabMapping> coinPrefabMappings;
    private Dictionary<int, GameObject> m_coinPrefabs;

    [SerializeField]
    private int m_minAmount = 10;
    [SerializeField]
    private int m_maxAmount = 20;

    [SerializeField]
    private int m_minOffset = 0;
    [SerializeField]
    private int m_maxOffset = 20;

    private List<Vector3> m_spawnedPositions = new List<Vector3>();

    private const int MAX_ATTEMPS_TO_FIND_POSITION = 3;


    void Start()
    {
        m_amount = Random.Range(m_minAmount, m_maxAmount);

        print(m_amount);
        
        FillPrefabsDictionary();
        SpawnMoney();

        PlayerInputManager.instance.playerJoinedEvent.AddListener(playerInput =>
        {
            InputActionMap playerMap = playerInput.actions.FindActionMap("Player");
            playerMap.FindAction("BasicAction").performed += this.Despawn;
        });
    }

    void Update()
    {
        
    }

    private void FillPrefabsDictionary()
    {
        m_coinPrefabs = new Dictionary<int, GameObject>();

        foreach (var mapping in coinPrefabMappings)
        {
            m_coinPrefabs[mapping.denomination] = mapping.prefab;
        }
    }

    private void SpawnMoney()
    {
        // For each coin prefab object in the dict...
        foreach (var coin in m_coinPrefabs)
        {
            int denomination = coin.Key;
            GameObject coinPrefab = coin.Value;

            if (m_amount == 0)
                break;

            int count = m_amount / denomination;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    SpawnCoinInNonOverlappingPosition(coinPrefab);
                }
            }

            if (coin.Key == 1)
            {
                RandomMoneySpawner(coinPrefab);
            }

            m_amount %= denomination;
        }
    }

    private GameObject SpawnCoinInNonOverlappingPosition(GameObject coinPrefab)
    {
        GameObject spawnedPrefab = Instantiate(coinPrefab, transform);
        RectTransform coinsRectTransform = spawnedPrefab.GetComponent<RectTransform>();

        float rectWidth = coinsRectTransform != null ? coinsRectTransform.rect.width : 40f;
        Vector2 position = GetNonOverlappingOffset(rectWidth);

        spawnedPrefab.transform.Translate(position);
        m_spawnedPositions.Add(spawnedPrefab.transform.position);

        return spawnedPrefab;
    }

    private Vector2 GetNonOverlappingOffset(float coinWidth)
    {
        Vector2 position = Vector2.zero;
        int attempts = 0;

        while (attempts < MAX_ATTEMPS_TO_FIND_POSITION)
        {
            float randomOffsetX = Random.Range(m_minOffset + attempts * 3, m_maxOffset);
            float randomOffsetY = Random.Range(m_minOffset + attempts * 3, m_maxOffset);
        
            position = new Vector2(randomOffsetX, randomOffsetY);

            bool isOverlapping = false;

            foreach (Vector2 spawnedPosition in m_spawnedPositions)
            {
                if (Vector2.Distance(position, spawnedPosition) < coinWidth)
                {
                    isOverlapping = true;
                    break;
                }
            }

            if (!isOverlapping)
                return position;

            attempts++;
        }

        return position;
    }

    private void RandomMoneySpawner(GameObject coinPrefab)
    {
        float chance = 0.5f;
        if (Random.value < chance)
        {
            GameObject spawnedCoin = SpawnCoinInNonOverlappingPosition(coinPrefab);
            Image coinSprite = spawnedCoin.GetComponent<Image>();

            coinSprite.color = Color.red;
        }
    }

    private void Despawn(InputAction.CallbackContext ctx)
    {
        Destroy(gameObject);
    }

    public void DestroyOnReturn()
    {
        Destroy(gameObject);
    }
}

[System.Serializable]
public class CoinPrefabMapping
{
    public int denomination;
    public GameObject prefab;
}