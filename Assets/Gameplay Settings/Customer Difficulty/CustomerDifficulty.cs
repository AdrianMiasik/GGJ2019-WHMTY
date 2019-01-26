using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Customer Difficulty" , menuName = "Designer/Gameplay/Create New Customer Difficulty")]
public class CustomerDifficulty : ScriptableObject
{
    // The rate at which customers arrive at 
    public float minTimeBetweenCustomers = 5f;
    public float maxTimeBetweenCustomers = 10f;

    // The patience of the customer
    public float minTimeBeforeLeaving = 5f;
    public float maxTimeBeforeLeaving = 10f;
}
