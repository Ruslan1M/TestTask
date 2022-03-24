using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LocalizationManager : MonoBehaviour
{
    public Text playText;
    
    public void Ru(string text)
    {
        playText.text = text;
        Events.onLanguageSaved();
    }

    public void Eng(string text)
    {
        playText.text = text;
        Events.onLanguageSaved();
    }

    public void Uk(string text)
    {
        playText.text = text;
        Events.onLanguageSaved();
    }
}
