using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitscript : MonoBehaviour
{
    //[SerializeField] public Transform otherpos;
    public GameObject finish;
    public spawner spawn;
    public Transform otherr;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "merge")
        {
            // otherpos = other.transform;

            otherr = other.transform;

           
            if (other.GetComponent<merge>().ispassed == true)
            {
                finish.SetActive(true);
            }

        }
        else
        {
            other = null;
        }


       
    }
    private void OnTriggerExit(Collider other)
    {
        if (otherr.gameObject.tag == "merge")
        {
            //if(other.gameObject.GetComponent<merge>().isdrop == true)
            {

                StartCoroutine(waitt());
           
           
            }
        }
        }
    public IEnumerator waitt()
    {
        yield return new WaitForSeconds(0.3f);
        spawn.ShowItem();
        otherr.GetComponent<merge>().ispassed = true;
    }
}
