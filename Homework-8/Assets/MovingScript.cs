using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{ 

    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public Transform Point4;
    public Transform Point5;
    public Transform Point6;
    public Transform Point7;

    public static event Action<GameObject> FlagChanged;

    private Vector3[] Points;
    private GameObject[] Objects;

    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;

    private Vector3 CurrentPoint;

    [SerializeField]private GameObject CurrObject;
    [SerializeField]private GameObject CurrentHandGrabber;

    private int NumberOfPoint = 0;
    private int NumberOfObject = 0;

    private bool Reverse = false;

    void Start()
    {
        Points = new Vector3[7];

        Points[0] = Point1.position;
        Points[1] = Point2.position;
        Points[2] = Point3.position;
        Points[3] = Point4.position;
        Points[4] = Point5.position;
        Points[5] = Point6.position;
        Points[6] = Point7.position;

        CurrentPoint = Points[0];

        Objects = new GameObject[6];
        Objects[0] = Object1;
        Objects[1] = Object2;
        Objects[2] = Object3;
        Objects[3] = Object4;
        Objects[4] = Object5;
        Objects[5] = Object6;

        CurrObject = Objects[0];

        CurrObject.transform.LookAt(CurrentPoint);

    }

    void Update()
    {
        if (CurrentPoint == CurrObject.transform.position)
        {
            ChangeCurrentPoint();
            CurrObject.transform.LookAt(CurrentPoint,Vector3.up);
        }

        CurrObject.transform.position = Vector3.MoveTowards(CurrObject.transform.position, CurrentPoint, 0.005f);
    }

    private void ChangeCurrentPoint()
    {

        if (NumberOfPoint == 6 && NumberOfObject == 5 || NumberOfPoint == 0 && NumberOfObject == 0)
        {
            Reverse = !Reverse;
        }       
        else
        {
            ChangeCurrentObject();
        }

        int ReverseNumber = Reverse == false ? 1 : -1;

        if (Reverse)
        {
            Points[NumberOfPoint] += new Vector3(0.5f, 0f, 0.5f);            
        }
        else            
        {
            Points[NumberOfPoint] += new Vector3(-0.5f, 0f, -0.5f);
        }

        CurrentPoint = Points[NumberOfPoint + ReverseNumber];
        
        NumberOfPoint += ReverseNumber;        
    }
    private void ChangeCurrentObject()
    {

        int ReverseNumber = Reverse == false ? 1 : -1;
        int CurrentIndex = NumberOfObject + ReverseNumber;

        CurrObject = Objects[CurrentIndex];

        CurrentHandGrabber = GameObject.Find("GrabHand"+ CurrentIndex.ToString());

        Debug.Log("GrabHand" + CurrentIndex.ToString());

        FlagChanged?.Invoke(CurrentHandGrabber);

        NumberOfObject += ReverseNumber;
    }
}
