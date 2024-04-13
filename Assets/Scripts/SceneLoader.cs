using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1)); // vai para a próxima cena
        // alterar para mudar para cena desejada quando tiver mais cenas
    }
    public void VoltarMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadScene(0)); // volta pro menu
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime); // pausa a rotina pelo tempo definido

        SceneManager.LoadScene(levelIndex);
    }
}
