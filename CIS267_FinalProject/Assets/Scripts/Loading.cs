using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    public float delayBeforeLevelLoad = 3f;

    void Start()
    {
        StartCoroutine(LoadingRoutine());
    }

    IEnumerator LoadingRoutine()
    {
        yield return new WaitForSeconds(delayBeforeLevelLoad);
        SceneManager.LoadScene("Level01");
    }
}
