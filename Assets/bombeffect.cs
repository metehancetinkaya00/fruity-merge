using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombeffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
