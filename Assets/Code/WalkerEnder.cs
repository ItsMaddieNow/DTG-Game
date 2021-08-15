using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class WalkerEnder : MonoBehaviour
{
    [SerializeField]
    BezierWalkerWithSpeed Walker;
    public void end(){
        Walker.enabled = false;
    }

}
