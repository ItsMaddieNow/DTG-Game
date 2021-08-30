using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Quitter : MonoBehaviour
{
    [SerializeField]
    GameObject ExitPrompt;
    QuitType QuitTo = QuitType.Title;
    [SerializeField]
    TMP_Text TextField;



    

    public enum QuitType{
        Title,
        OS,
        Undefined
    }
    QuitType StringToQuitType(string quitType){
        switch(quitType)
        {
            case "Title":
                return QuitType.Title;
            case "OS":
                return QuitType.OS;
            default:
                return QuitType.Undefined;
        }
    }
    public void QuitInitialize(string InputQuitTo){
        QuitTo = StringToQuitType(InputQuitTo);
        ExitPrompt.SetActive(true);
        TextField.text = "Are you sure you want to exit?\nYou last Saved " + (System.DateTime.Now-File.GetLastWriteTime(SaveManagement.SaveSlotDir + "/SaveData.json")).Minutes + " Minutes Ago";
    }
    // Start is called before the first frame update
    public void QuitContinue()
    {
        switch(QuitTo)
        {
            case QuitType.Title:
                SceneManager.LoadScene("Main menu");
                break;
            case QuitType.OS:
                Application.Quit();
                break;
            default:
                break;
        }
    }
    public void QuitCancel(){
        ExitPrompt.SetActive(false);        
    }
}
