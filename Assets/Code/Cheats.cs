using UnityEngine;
using TMPro;

public class Cheats : MonoBehaviour
{
    public TMP_InputField IF;
    void Start()
    {
        IF = GetComponent<TMP_InputField>();
    }
    public void Submit() {
        switch (IF.text)
        {
            case "TurtleSavingIsAHobby":
                Death.TurtleSavingIsAHobby = true;
                return;
            case "AllTools":
                PlayerAbilities.TorchAvaliable = true;
                PlayerAbilities.GrapplingHookAvaliable = true;
                return;
            case "NoTools":
                PlayerAbilities.TorchAvaliable = false;
                PlayerAbilities.GrapplingHookAvaliable = false;
                return;
            default:
                Debug.Log("Unknown Command \"" + IF.text + "\"");
                return;
        }
    }
}
