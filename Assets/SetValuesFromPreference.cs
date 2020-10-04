using UnityEngine;
using UnityEngine.UI;

public class SetValuesFromPreference : MonoBehaviour
{
    public Toggle menu_tog;
    public Toggle game_tog;
    // Update is called once per frame
    void Awake()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        for (int i = 0; i < SaveAsPreference.Dic_names.Count; i++)
        {
            if (SaveAsPreference.Dic_names[i].Contains("Menu"))
            {
                if (PlayerPrefs.GetInt(SaveAsPreference.Dic_names[i]) == 1)
                {
                    menu_tog.isOn = true;
                }
                else
                {
                    menu_tog.isOn = false;
                }
            }
            else
            {
                if (PlayerPrefs.GetInt(SaveAsPreference.Dic_names[i]) == 1)
                {
                    game_tog.isOn = true;
                }
                else
                {
                    game_tog.isOn = false;
                }
            }
        }
    }

}
