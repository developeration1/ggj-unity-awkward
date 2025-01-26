using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] float secondsToWait;
    [SerializeField] string scene;
    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneRoutine());
    }

    private IEnumerator ChangeSceneRoutine()
    {
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(name);
    }
}
