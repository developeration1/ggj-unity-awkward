using UnityEngine;
using System.Collections;

public class RandomWave : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private float m_minDelay = 2f;
    [SerializeField]
    private float m_maxDelay = 5f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        float chance = 0.5f;
        float randomDelay = Random.Range(m_minDelay, m_maxDelay);

        StartCoroutine(SetBoolAfterDelay(Random.value > chance ? "Wave" : "Exit", randomDelay));
    }

    private IEnumerator SetBoolAfterDelay(string param, float randomDelay)
    {
        yield return new WaitForSeconds(randomDelay);
        animator.SetBool(param, true);
    }
}
