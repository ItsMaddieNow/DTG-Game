using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class LavaManager : MonoBehaviour
{
    public Transform StartPosition;
    public Transform SwingingCheckpoint;
    public Transform FinalPosition;
    public BezierWalkerWithSpeed FirstWalker;
    public BezierWalkerWithSpeed SecondWalker;
    //public LavaState CurrentState = LavaState.Start;
    public enum LavaState {
        Start,
        SwingingSubmerged,
        Finished
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = LavaPos(SaveManagement.saveData.lavaState);
    }
    public Vector2 LavaPos (LavaState State){
        switch (State){
            case LavaState.Start:
                return StartPosition.position;
            case LavaState.SwingingSubmerged:
                return SwingingCheckpoint.position;
            case LavaState.Finished:
                return FinalPosition.position;
            default:
                return Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
