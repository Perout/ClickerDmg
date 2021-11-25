using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuHelper : MonoBehaviour
{
    public Text MyGoldText;
    public Text RecordText;

    public void ShowEndGame(int gold)
    {
        MyGoldText.text = MyGoldText.ToString();
        if (SettingClass.GoldRecord<gold)
        {
            SettingClass.GoldRecord = gold;
        }
        RecordText.text = SettingClass.GoldRecord.ToString();
    }
    public void ButtonRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
}
