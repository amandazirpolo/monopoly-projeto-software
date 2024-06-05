using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private bool isPaused;
    [SerializeField]
    private GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {        
        menu.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        menu.SetActive(true);
        isPaused = true;
    }
}
