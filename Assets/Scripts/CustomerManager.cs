using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    /// <summary>
    /// Customer Prefab
    /// </summary>
    [SerializeField] protected Customer customerPrefab;
    
    /// <summary>
    /// A list of all the active customers in the game.
    /// </summary>
    [SerializeField] private List<Customer> allCustomers = new List<Customer>();

    /// <summary>
    /// Returns a list of all the active customers in the game.
    /// </summary>
    /// <returns></returns>
    public List<Customer> GetAllCustomers()
    {
        return allCustomers;
    }

    /// <summary>
    /// Returns a random active customer.
    /// </summary>
    /// <returns></returns>
    public Customer GetRandomCustomer()
    {
        return allCustomers[Random.Range(0, GetAllCustomers().Count)];
    }
    
    /// <summary>
    /// Create a customer.
    /// </summary>
    /// <param name="sp"></param>
    public void CreateCustomer(Spawnpoint sp)
    {
        // If that spawnpoint is not occupied...
        if (!sp.IsOccupied)
        {
            // Create a customer
            Customer _customer = Instantiate(customerPrefab, sp.transform);
            allCustomers.Add(_customer);
            
            // Provide customer with a spawnpoint reference so when the customer is done being served, they know what spawn point they can clear
            _customer.spawnpoint = sp;

            // TODO: Refactor the way this is done...But who am I kidding, its a game jam :D Never going to happen
            // Provide spawnpoint with a reference to this class so if the spawnpoint no longer exists, the customer can destroy itself.
            sp.customer = _customer;
            _customer.manager = this;
            
            // Mark the spawnpoint as occupied
            sp.Occupy();
        }
    }

    /// <summary>
    /// Removes the customer from the game.
    /// </summary>
    /// <param name="_customer"></param>
    public void RemoveCustomer(Customer _customer)
    {
        // TODO: Determine score
        
        _customer.spawnpoint.Unoccupy();
        allCustomers.Remove(_customer);
        Destroy(_customer.gameObject);
    }
}
