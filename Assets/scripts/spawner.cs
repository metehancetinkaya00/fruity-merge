using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public WeightedRandomList<Transform> lootTable;
    //   private merge merg;
    public Transform itemHolder;
    //   public Rigidbody rb;
    //  Animator animator;

    void Start()
    {
        //merg = FindObjectOfType<merge>();
        // animator = GetComponent<Animator>();
        //   ShowItem();
    }

    void Update()
    {

        // animator.SetTrigger("close");




    }



    void HideItem()
    {
        itemHolder.localScale = Vector3.zero;
        itemHolder.gameObject.SetActive(false);

        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }
    }

    public void ShowItem()
    {
        Transform item = lootTable.GetRandom();
        // item.GetComponent<Rigidbody>().isKinematic = false;
        Instantiate(item, itemHolder);
        itemHolder.gameObject.SetActive(true);

    }
}
