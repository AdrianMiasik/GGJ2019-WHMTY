using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
   // todo: change back to private
   public bool isOccupied;
   public bool IsOccupied => isOccupied;

   public void Occupy()
   {
      isOccupied = true;
   }

   public void Unoccupy()
   {
      isOccupied = false;
   }
}
