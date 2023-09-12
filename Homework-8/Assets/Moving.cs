using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Transform LeftFoot;
    public Transform RightFoot;
    public Transform LeftHand;
    public Transform RightHand;

    public float AngularVelocity;
    public int StepWidth;

    private Vector3 LastPosition;

    private float LeftFootAngle;
    private float RightFootAngle;
    private float LeftHandAngle;
    private float RightHandAngle;

    private float FootAngleRange;

    private bool Reverse = false;
    private bool isMoving = false;

    private int DirectionLeftFoot;
    private int DirectionRightFoot;
    private int DirectionLeftHand;
    private int DirectionRightHand;

    
    
    void Start()
    {        
        FootAngleRange = 0;
        LeftFootAngle = 15;
        RightFootAngle = -15;
        LeftHandAngle = 15;
        RightHandAngle = -15;
    }

    // Update is called once per frame
    void Update()
    {

        if (LastPosition != transform.position && isMoving == false)
        {
            isMoving = !isMoving;
        }
        else if (LastPosition == transform.position && isMoving == true)
        {
            isMoving = !isMoving;
        }

        if (isMoving)
        {
            if (FootAngleRange >= StepWidth)
            {
                Reverse = !Reverse;
                FootAngleRange = 0;
            }

            DirectionLeftFoot = Reverse ? 1 : -1;
            DirectionRightFoot = Reverse ? -1 : 1;
            DirectionLeftHand = Reverse ? 1 : -1;
            DirectionRightHand = Reverse ? -1 : 1;

            LeftFootAngle += (AngularVelocity * DirectionLeftFoot);
            RightFootAngle += (AngularVelocity * DirectionRightFoot);
            LeftHandAngle += (AngularVelocity * DirectionLeftHand);
            RightHandAngle += (AngularVelocity * DirectionRightHand);

            LeftFoot.rotation = Quaternion.Euler((int)LeftFootAngle, 0, 0);
            RightFoot.rotation = Quaternion.Euler((int)RightFootAngle, 0, 0);
            LeftHand.rotation = Quaternion.Euler((int)LeftHandAngle, 0, 0);
            RightHand.rotation = Quaternion.Euler((int)RightHandAngle, 0, 0);

            FootAngleRange += AngularVelocity;
        }
        
        LastPosition = transform.position;

    }
}
