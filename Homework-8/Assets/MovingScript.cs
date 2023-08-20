using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    private Vector3[] Points;

    public GameObject CurrentObject;

    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public Transform Point4;
    public Transform Point5;
    public Transform Point6;
    public Transform Point7;

    [SerializeField]private Vector3 CurrentPoint;

    [SerializeField] private int NumberOfPoint = 1;
    //[SerializeField] private int NextPoint = 2;

    [SerializeField] private bool Reverse = false;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPoint == CurrentObject.transform.position)
        {
            ChangeCurrentPoint();
        }

        CurrentObject.transform.position = Vector3.MoveTowards(CurrentObject.transform.position, CurrentPoint, 0.005f);
    }

    private void ChangeCurrentPoint()
    {

        if (NumberOfPoint == 0 || NumberOfPoint == Points.Length-1)
        {
            Reverse = !Reverse;
            //NextPoint = NumberOfPoint;
        }

        int ReverseNumber = Reverse == false ? 1 : -1;            

        CurrentPoint = Points[NumberOfPoint + ReverseNumber];

        NumberOfPoint += ReverseNumber;
       // NextPoint += ReverseNumber;

    }
}
