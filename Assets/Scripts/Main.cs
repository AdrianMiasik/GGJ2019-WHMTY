using UnityEngine;

public class Main : MonoBehaviour
{
    public CustomerManager customerManager;
    public CustomerDifficulty settings;
    
    public SpawnpointManager spawnManager;

    private bool isInitialized = false;

    private static float gameTimer;
    private static float currentCustomerTimer;
    private static float spawnCustomerTime;

    private static int numberOfSpawnCustomers;
    
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (isInitialized)
        {
            gameTimer += Time.deltaTime;
            currentCustomerTimer += Time.deltaTime;

            // Rate of the when a new customer will show up
            if (currentCustomerTimer >= spawnCustomerTime)
            {                
                // Reset timer
                currentCustomerTimer = 0f;
                
                // If there are no spawnpoints to put a customer at...
                if (spawnManager.GetOpenSpawnpoints().Count <= 0)
                {
                    // Create a spawnpoint
                    spawnManager.Create();
                }
                
                // Spawn a customer
                SpawnCustomer();

                // Get new time when the next customer should arrive
                spawnCustomerTime = FetchNewCustomerTimings();
                
                // TODO: Increase the difficulty here
            }

            # region DEBUGGING
            if (Developer.allowDebugControls)
            {
                // A for Add Customer
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SpawnCustomer();
                }
                // R for Remove Customer
                if (Input.GetKeyDown(KeyCode.R))
                {
                    RemoveRandomCustomer();
                }
            }
            #endregion
        }
    }

    /// <summary>
    /// This will create a customer that the player will have to serve.
    /// </summary>
    private void SpawnCustomer()
    {
        numberOfSpawnCustomers++;
        Spawnpoint spawn = spawnManager.FetchRandomOpenSpawnpoint();
        if (spawn != null)
        {
            customerManager.CreateCustomer(spawn);
        }
    }
    
    /// <summary>
    /// Removes a random customer from the game. Note: This function will determine scoring
    /// </summary>
    private void RemoveRandomCustomer()
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

    /// <summary>
    /// Generates the new timing of the next character controller
    /// </summary>
    public float FetchNewCustomerTimings()
    {
        float timing = Random.Range(settings.minTimeBetweenCustomers, settings.maxTimeBetweenCustomers);
        return timing;
    }

    public void Initialize()
    {
        spawnManager.Generate();
        SpawnCustomer();

        spawnCustomerTime = FetchNewCustomerTimings();
        isInitialized = true;
    }
}
