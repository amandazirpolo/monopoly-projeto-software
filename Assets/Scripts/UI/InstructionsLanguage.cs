using UnityEngine;

public class InstructionsLanguage : MonoBehaviour
{
    [SerializeField]
    private GameObject instPt, instEn;
    private LanguageController languageManager;

    void Start()
    {
        languageManager = FindObjectOfType<LanguageController>();
    }

    void Update()
    {
        if (languageManager.getLanguage() == "pt")
        {
            instEn.SetActive(false);
        }
        if (languageManager.getLanguage() == "en")
        {
            instPt.SetActive(false);
        }
    }
}
