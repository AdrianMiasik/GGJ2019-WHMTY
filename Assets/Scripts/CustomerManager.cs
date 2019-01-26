using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public int numberOfSpawnpoints = 4;
    public GameObject spawnpoint;

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Creates spawn points for the customers
    /// </summary>
    private void Initialize()
    {
        for (int i = 0; i < numberOfSpawnpoints; i++)
        {
            
        }
    }
}
