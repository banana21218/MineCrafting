using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Curser : MonoBehaviour
{
    public GameObject Parent;
    public GameObject point;
    private bool drawing = false;
    private float distance;
    private Vector3 startDist;
    [SerializeField]
    private GameObject Drawing;
    private Ray ray;
    private Vector3 rayPoint;



    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            drawing = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            rayPoint = ray.GetPoint(distance);
            Drawing = Instantiate(point);
            Drawing.transform.position = rayPoint;
            startDist = transform.position - rayPoint;
        }
        

    }
    private void OnMouseDown()
    {
        Destroy(point);
    }
    public void Update()
    {
        if (drawing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
        }
    }
}
