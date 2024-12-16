using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

    private Color mouseOverColor = Color.red;
    private Color originalColor = Color.green;
    private bool dragging = false;
 //   public ParticleSystem blood;
    [SerializeField] float gridSnapSize = 5;
    [SerializeField] float fixedHieght = 5;

    private void Update()
    {
        if (dragging)//_drag == null &&
        {
            Transform draggingObject = transform;

            Plane plane = new Plane(Vector3.up, Vector3.up * fixedHieght); // ground plane

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                Vector3 rayPoint = ray.GetPoint(distance);
                Vector3 snappedRayPoint = rayPoint;
                snappedRayPoint.x = (Mathf.RoundToInt(rayPoint.x / gridSnapSize) * gridSnapSize);
                snappedRayPoint.y = (Mathf.RoundToInt(rayPoint.y / gridSnapSize) * gridSnapSize);
                draggingObject.position = snappedRayPoint;
            }
        }
    }
    void OnMouseDown()
    {
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
}
