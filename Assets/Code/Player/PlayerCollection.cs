using UnityEngine;
using System;
public class PlayerCollection : MonoBehaviour {
    public Transform PlayerTransform;
    public PlayerMovement PlayerMovement;

    private void Awake() {
        PauseMenu.PC = this;
    }
}