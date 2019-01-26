using UnityEngine;

public class Main : MonoBehaviour
{
    public CustomerManager customerManager;
    public SpawnpointManager spawnManager;

    private bool isInitialized = false;
    
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (isInitialized)
        {
            if (Developer.allowDebugControls)
            {
                // A for Add
                if (Input.GetKeyDown(KeyCode.A))
                {
                    customerManager.CreateCustomer(spawnManager.GetOpenSpawnpoint());
                }
                // R for Remove
                if (Input.GetKeyDown(KeyCode.R))
                {
                    // If we actually have customers to delete...
                    if (customerManager.GetAllCustomers().Count >= 1)
                    {
                        customerManager.RemoveCustomer(customerManager.GetRandomCustomer());
                    }
                }
            }
        }
    }

    public void Initialize()
    {
        spawnManager.Generate();
        isInitialized = true;
    }
}
