using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] Menus;
    public void switchMenu(int MenuIndex){
        int index = 0;
        foreach(GameObject CurrentMenu in Menus){
            CurrentMenu.SetActive(index==MenuIndex);
            index++;
        }
    }
}
