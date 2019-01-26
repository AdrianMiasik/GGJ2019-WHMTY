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
                    Spawnpoint spawn = spawnManager.FetchRandomOpenSpawnpoint();
                    if (spawn != null)
                    {
                        customerManager.CreateCustomer(spawn);
                    }
                }
                // R for Remove
                if (Input.GetKeyDown(KeyCode.R))
                {
                    // If we actually have customers to delete...
                    if (customerManager.GetAllCustomers().Count >= 1)
                    {
                        customerManager.RemoveCustomer(customerManager.GetRandomCustomer());
                    }
                    else
                    {
                        if (Developer.showMessages)
                        {
                            Debug.Log("You are try to delete a customer but there are none in the game!");
                        }
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
