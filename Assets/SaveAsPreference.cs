using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAsPreference : MonoBehaviour
{
    public string Dictionary_name;
    public static List<string> Dic_names = new List<string>();
    public SetValuesFromPreference SVFP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetIt()
    {
        if(PlayerPrefs.HasKey(Dictionary_name))
        {
            int get_val = PlayerPrefs.GetInt(Dictionary_name);
            if(get_val == 1)
            {
                PlayerPrefs.SetInt(Dictionary_name, 0);
            }
            else
            {
                PlayerPrefs.SetInt(Dictionary_name, 1);
            }
        }
        else
        {
            Dic_names.Add(Dictionary_name);
            PlayerPrefs.SetInt(Dictionary_name, 0);
        }
    }

}
