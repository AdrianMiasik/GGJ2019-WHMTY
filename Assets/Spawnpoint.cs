using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
   private bool isOccupied;
   public bool IsOccupied => isOccupied;

   private SpawnpointManager manager;

   public Customer customer;

   public void ProvideSpawnpointManager(SpawnpointManager spawnManager)
   {
      manager = spawnManager;
   }
   
   public void Occupy()
   {
      if (manager == null)
      {
         Debug.LogWarning("Please provide this spawnpoint with a spawnpoint manager reference so we can remove ourselves from the open spawnpoints list when we are occupied.");
         return;
      }
      
      manager.openSpawnpoints.Remove(this);
      isOccupied = true;
   }

   public void Unoccupy()
   {
      if (manager == null)
      {
         Debug.LogWarning("Please provide this spawnpoint with a spawnpoint manager reference so we can add ourselves back to the open spawnpoints list so some other customer can use this spot");
         return;
      }
      
      manager.openSpawnpoints.Add(this);
      isOccupied = false;
   }
}
