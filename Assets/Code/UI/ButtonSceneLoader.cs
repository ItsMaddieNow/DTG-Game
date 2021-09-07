using UnityEngine;

public class ButtonSceneLoader : MonoBehaviour {
    public MainLevelLoad LoadManager;
    public void LoadLevel() {
        LoadManager.LoadLevel();
    }
}