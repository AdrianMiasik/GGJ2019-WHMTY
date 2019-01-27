using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Customer : MonoBehaviour
{
    public Spawnpoint spawnpoint { get; set; }


    public CustomerDifficulty settings;
    public Image bubbleImage;

    private Animator animator;
    private float patience;
    private float timeWaiting;
    [SerializeField] private Transform bubble;

    public GameObject Item;
    private List<Item> WantedItemList;
    public HashSet<Item.ItemType> WantedItems;

    private void AssignWantedItems()
    {
        WantedItemList = new List<Item>();
        for(int i = 0; i < 6; i++)
        {
            GameObject newItem = Instantiate(Item, bubble);
            newItem.transform.position += new Vector3(-70 + i * 30f, -10f, 0f);
            WantedItemList.Add(newItem.GetComponent<Item>());
            Debug.LogError("item: " + newItem.GetComponent<Item>());
        }
    }

    private void Start()
    {
        patience = 200;

        animator = GetComponent<Animator>();
        AssignWantedItems();
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
        int score = CalculateScore(shell);
        Destroy(shell.gameObject);
        GameManager.Instance.RateStore(score);
        StartCoroutine(OnShellRecevied(score));
    }

    private int CalculateScore(Shell shell)
    {
        Debug.LogError("calculate score");
        WantedItems = new HashSet<Item.ItemType>();
        foreach(Item v in WantedItemList)
        {
            WantedItems.Add(v.Type);
        }
        float score = 0f;
        foreach (Slot slot in shell.Slots)
        {
            if (slot.IsAttached)
            {
                Debug.LogError("check score");
                if (WantedItems.Remove(slot.attachedItem.Type))
                {
                    score++;
                    Debug.LogError("Find num: " + score);
                }
            }
        }
        Debug.LogError("score: " + (int)Mathf.Round(10f / shell.Slots.Count * score));
        return (int)Mathf.Round(10f / shell.Slots.Count * score);
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
    