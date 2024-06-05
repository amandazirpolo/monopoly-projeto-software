using TMPro;
using UnityEngine;

public class ChangeableLanguage : MonoBehaviour
{
    [SerializeField]
    private string textPt, textEn;
    [SerializeField]
    private TMP_Text publicText;
    private LanguageController languageManager;

    void Start()
    {
        languageManager = FindObjectOfType<LanguageController>();
    }
    void Update()
    {
        if (languageManager.getLanguage() == "pt")
        {
            publicText.text = textPt;
        }
        if (languageManager.getLanguage() == "en")
        {
            publicText.text = textEn;
        }
    }
}

