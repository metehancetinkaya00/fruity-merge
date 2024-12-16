 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merge : MonoBehaviour
{
   // [SerializeField] public float thrust;
   // public Vector3 moveDirection;
    public int ID;
    public GameObject MergedObject;
    Transform Block1;
    Transform Block2;
    public float Distance;
    public float MergeSpeed;
   public bool CanMerge,isfinished,isdrop,ispassed,isbomb;
    public Rigidbody rb;
    public Transform direct;
      public ParticleSystem stars;
    private scoremanager managerscore;
    public 
    // Start is called before the first frame update
    void Start()
    {
        managerscore = FindObjectOfType<scoremanager>();
        rb=  GetComponent<Rigidbody>();
        ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
      
      // this.MergedObject.GetComponent<Rigidbody>().isKinematic = false;
        if (CanMerge == true)
        {
            MoveTowards();
          
        }
    }

   
    public void MoveTowards()
    {
        if (CanMerge==true)
        {
            

            transform.position = Vector3.MoveTowards(Block1.position, Block2.position, MergeSpeed);
            if (Vector3.Distance(Block1.position, Block2.position) < Distance)
            {
                if (ID < Block2.gameObject.GetComponent<merge>().ID) { return; }
                Debug.Log($"SENDING MESSAGE FROM {gameObject.name} With The ID Number of{ID}");
                GameObject O = Instantiate(MergedObject, transform.position, Quaternion.identity) as GameObject;

               
                O.GetComponent<merge>().rb.isKinematic=false;
                O.GetComponent<merge>().ispassed = true;
               
               // moveDirection = O.GetComponent<Rigidbody>().transform.position - direct.transform.position;
               // O.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * thrust);
                O.GetComponent<merge>().stars.Play();
                Destroy(Block2.gameObject);
                    Destroy(gameObject);

                
              
            }
        }
    }
   
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="merge")
        {
            direct = collision.transform;
            if (collision.gameObject.name == gameObject.name)
            {
               
                if (isfinished==false)
                {
                    

                        managerscore.scorecount += 1;


                    Block1 = transform;
                Block2 = collision.transform;
                   // MergedObject.GetComponent<Rigidbody>().isKinematic = false;
                CanMerge = true;
                }
                //  Destroy(collision.gameObject.GetComponent<Rigidbody>());
                //  Destroy(GetComponent<Rigidbody>());

            }
           
        }
    }
   
}
