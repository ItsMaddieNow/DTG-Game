using UnityEngine;

public class LevelLoadingBar : MonoBehaviour {
    [SerializeField] RectTransform Bar;
    public AsyncOperation Progress;
    void Update() {
        Bar.localScale = new Vector3(Progress.progress,1,1); 
    }
}