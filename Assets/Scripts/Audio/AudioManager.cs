using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetVolume(0.5f);
        audioSource.Play();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetVolumeSlider(Slider volSlider)
    {
        audioSource.volume = volSlider.value;
    }
}
