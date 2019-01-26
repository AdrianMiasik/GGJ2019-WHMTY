using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointManager : MonoBehaviour
{        
    public int numberOfStartingSpawnpoints = 4;
    public GameObject spawnpointPrefab;
    public Transform spawnpointContainer;

    private int numberOfSpawnPoints;
    
    [SerializeField] private List<Spawnpoint> spawnpoints = new List<Spawnpoint>();

    /// <summary>
    /// Adds spawnpoints to the list. (Unless it has already been registered.)
    /// </summary>
    /// <param name="sp"></param>
    public void Register(Spawnpoint sp)
    {
        // If our spawn point isnt registered...
        if (!spawnpoints.Contains(sp))
        {
            // Add or register it.
            spawnpoints.Add(sp);
        }
        else
        {
            Debug.LogWarning("This spawnpoint has already been registered!");
        }
    }

    /// <summary>
    /// Deregisters spawnpoints from the list. (As long as the proviced spawnpoint is within the list.)
    /// </summary>
    /// <param name="sp"></param>
    public void Deregister(Spawnpoint sp)
    {
        if (spawnpoints.Contains(sp))
        {
            spawnpoints.Remove(sp);
        }
        else
        {
            Debug.LogWarning("This spawn point has never been registered or has already been removed.");
        }
    }

    private void Update()
    {
        if (Developer.allowDebugControls)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Create();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Destroy();
            }
        }
    }

    /// <summary>
    /// Deregisters and destroys the last registered spawnpoint safely.
    /// </summary>
    public void Destroy()
    {
        // If there are no spawn points, thendon't do anything.
        if (spawnpoints.Count <= 0) return;
        
        Spawnpoint lastRegisteredSpawn = spawnpoints[spawnpoints.Count - 1];
        Deregister(lastRegisteredSpawn);
        Destroy(lastRegisteredSpawn.gameObject);
    }
    
    /// <summary>
    /// Generates spawnpoints for customers to arrive at / within.
    /// </summary>
    public void Generate()
    {
       for (int i = 0; i < numberOfStartingSpawnpoints; i++)
        {
            Create();
        }  
    }

    /// <summary>
    /// Creates a spawnpoint.
    /// </summary>
    public void Create()
    {
        GameObject spawnObj = Instantiate(spawnpointPrefab, spawnpointContainer.transform);
        Spawnpoint spawnpoint = spawnObj.AddComponent<Spawnpoint>();
            
        Register(spawnpoint);
    }
}
