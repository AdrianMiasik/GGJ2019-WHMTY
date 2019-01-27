using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public Spawnpoint spawnpoint { get; set; }

    public CustomerDifficulty settings;
    public Image bubbleImage;

    private Animator animator;
    private float patience;
    private float timeWaiting;

    private void Start()
    {
        patience = 20;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {   
        // Accumulate time
        timeWaiting += Time.deltaTime;

        // Patience of the customer
        if (timeWaiting >= patience / 2)
        {
            animator.SetBool("isAngry", true);
        }

        if (timeWaiting >= patience)
        {
            Remove();
        }
    }

    public void ShowDialogueBubble()
    {
        bubbleImage.gameObject.SetActive(true);
    }

    public void ReceiveShell(Shell shell)
    {
        Debug.LogError("Received shell");
        int score = shell.CalculateScore();
        Destroy(shell.gameObject);
        GameManager.Instance.RateStore(score);
        StartCoroutine(OnShellRecevied(score));
    }

    private IEnumerator OnShellRecevied(int score)
    {
        if (score <= 3)
        {
            animator.SetBool("isAngry", true);
        }
        else
        {
            animator.SetBool("isHappy", true);
            GameManager.Instance.AddTime(2f);
        }

        yield return new WaitForSeconds((float)animator.GetCurrentAnimatorClipInfo(0).Length);
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
    