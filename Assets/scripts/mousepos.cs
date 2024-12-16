using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class mousepos : MonoBehaviour
{
  //  public ParticleSystem efect;
    public float speed;
    Vector3 offset;
    Collider colder;
    public string destinationTag = "DropArea";
    public Rigidbody rb;
    public float limitxpos, limitxneg,limitypos,limityneg;
    public bool isdrop,isrotate;
    
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    void Awake()
    {
        colder = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(isrotate==true)
        {
            StartCoroutine(rot());
        }
    }

    public IEnumerator rot()
    {
        //  efect.Play();
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();

      //  fruitlimity();
    }
    public void fruitlimitx()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth-limitxneg-objectWidth, screenBounds.x - objectWidth-limitxpos+objectWidth);
      //  viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
        /*
         var pos = transform.position;
         pos.x = Mathf.Clamp(transform.position.x, limitxneg, limitxpos);
         transform.position = pos;
        */
    }
    public void fruitlimity()
    {
        var pos = transform.position;
        pos.y = Mathf.Clamp(transform.position.y, limityneg, limitypos);
        transform.position = pos;
    }
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
        fruitlimity();
        fruitlimitx();
        isdrop = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        isrotate = false;
        //   efect.Pause();
    }
    void OnMouseUp()
    {
        isrotate = true;
        rb.isKinematic = false;
        isdrop = true;
        colder.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
            }
        }
        colder.enabled = true;
    }
    
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.ScreenToWorldPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
