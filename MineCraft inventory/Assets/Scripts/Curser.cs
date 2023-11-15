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




    void OnMouseDown()
    {

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        drawing = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        Drawing = Instantiate(point);
        Drawing.transform.position = rayPoint;
        startDist = transform.position - rayPoint;

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
