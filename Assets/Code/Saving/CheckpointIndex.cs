using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointIndex : MonoBehaviour
{
    public List<Checkpoint> NumberToCheckpoint = new List<Checkpoint>();
    // Start is called before the first frame update
    void Start()
    {
        // doesn't restore state of the start checkpoint because it doesn't glow and will cause reference expections
        if (SaveManagement.saveData.CheckpointIndex == Checkpoint.CPIToInt(Checkpoint.Checkpoints.Start)) return;
        // Picks checkpoint based on index that is saved to file and quick starts it
        NumberToCheckpoint[SaveManagement.saveData.CheckpointIndex].SaveRestore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
