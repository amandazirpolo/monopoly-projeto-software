using UnityEngine;
using TMPro;

public class LanguageController : MonoBehaviour
{
    [SerializeField]
    private string language;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LanguageChanged(TMP_Dropdown dropdown)
    {
        language = dropdown.options[dropdown.value].text;
    }

    public void LanguageChangedImage(string lg)
    {
        language = lg;
    }
    public string getLanguage()
    {
        return language;
    }
}