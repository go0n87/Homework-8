using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{ 
    public static event Action<GameObject> FlagChanged;

    public Transform[] Points;
    public GameObject[] Objects;

    public float passDistance;

    private Vector3 CurrentPoint;

    [SerializeField]private GameObject CurrObject;
    [SerializeField]private GameObject CurrentHandGrabber;

    private int NumberOfPoint = 0;
    private int NumberOfObject = 0;

    private bool Reverse = false;

    
    void Start()
    {

        CurrentPoint = Points[0].position;
        CurrObject = Objects[0];
        CurrObject.transform.LookAt(CurrentPoint);       

    }

    void Update()
    {

        if (Vector3.Distance(CurrentPoint, CurrObject.transform.position) < passDistance)
        {
            ChangeCurrentPoint();
            CurrObject.transform.LookAt(CurrentPoint,Vector3.up);
        }

        CurrObject.transform.position = Vector3.MoveTowards(CurrObject.transform.position, CurrentPoint, 0.005f);
    }

    private void ChangeCurrentPoint()
    {
        
        if (NumberOfPoint == Points.Length-1 && NumberOfObject == Objects.Length - 1 || NumberOfPoint == 0 && NumberOfObject == 0)
        {
            Reverse = !Reverse;
        }       
        else
        {
            ChangeCurrentObject();
        }

        int ReverseNumber = Reverse == false ? 1 : -1;    

        CurrentPoint = Points[NumberOfPoint + ReverseNumber].position;
        
        NumberOfPoint += ReverseNumber;        
    }
    private void ChangeCurrentObject()
    {

        int ReverseNumber = Reverse == false ? 1 : -1;
        int CurrentIndex = NumberOfObject + ReverseNumber;

        CurrObject = Objects[CurrentIndex];

        CurrentHandGrabber = GameObject.Find("GrabHand"+ CurrentIndex.ToString());

        FlagChanged?.Invoke(CurrentHandGrabber);

        NumberOfObject += ReverseNumber;
    }
}
