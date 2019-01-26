using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public SpawnpointManager spawnpointManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        spawnpointManager.Generate();
        // TODO: Add crabs to the spawns
    }
}
