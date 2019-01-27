using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [HideInInspector] public Spawnpoint spawnpoint;

    public CustomerDifficulty settings;
    
    // TODO: A class for the UI which will generate a picture of what the people want
    public CustomerUIElement ui;

    private float patience;

    private float timeWaiting;

    private void Start()
    {
        patience = Random.Range(settings.minTimeBeforeLeaving,
            settings.maxTimeBeforeLeaving);
    }

    private void Update()
    {   
        // Accumulate time
        timeWaiting += Time.deltaTime;

        // Patience of the customer
        if (timeWaiting >= patience)
        {
            Debug.Log("You took too long, I'm leaving! I can find better service across the street.");
            Remove();
        }
    }

    public void ReceiveShell(Shell shell)
    {
        Debug.LogError("Received shell");
        int score = shell.CalculateScore();
        Destroy(shell.gameObject);
        StartCoroutine(OnShellRecevied(score));
    }
     

    private IEnumerator OnShellRecevied(int score)
    {
        if (score <= 3)
        {
            Remove();
            yield break;
        }
        else
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("isHappy", true);
            yield return new WaitForSeconds((float)animator.GetCurrentAnimatorClipInfo(0).Length);
        }
        Remove();
    }

    /// <summary>
    /// This reference gets passed through when this object is created.
    /// </summary>
    public CustomerManager manager;
    
    /// <summary>
    /// Removes self from the game and also scores.
    /// </summary>
    public void Remove()
    {
        if (manager == null)
        {
            Debug.LogAssertion("Please provide this class with a reference to the customer manager so we can remove ourselves from the appropriate lists.");
            return;
        }
        
        manager.RemoveCustomer(this);
    }
}
    