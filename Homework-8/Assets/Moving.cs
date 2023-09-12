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

    [SerializeField] private float LeftFootAngle;
    [SerializeField] private float RightFootAngle;
    [SerializeField] private float LeftHandAngle;
    [SerializeField] private float RightHandAngle;

    [SerializeField] private float FootAngleRange;

    private bool Reverse = false;

    [SerializeField] private int DirectionLeftFoot;
    [SerializeField] private int DirectionRightFoot;
    [SerializeField] private int DirectionLeftHand;
    [SerializeField] private int DirectionRightHand;

    // Start is called before the first frame update
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
        if (FootAngleRange >= StepWidth)
        {
            Reverse = !Reverse;
            FootAngleRange = 0;
        }

        DirectionLeftFoot = Reverse ? 1 : -1;
        DirectionRightFoot = Reverse ? -1 : 1;
        DirectionLeftHand = Reverse ? 1 : -1;
        DirectionRightHand = Reverse ? -1 : 1;

        LeftFootAngle = LeftFootAngle + (AngularVelocity * DirectionLeftFoot);
        RightFootAngle = RightFootAngle + (AngularVelocity * DirectionRightFoot);
        LeftHandAngle = LeftHandAngle + (AngularVelocity * DirectionLeftHand);
        RightHandAngle = RightHandAngle + (AngularVelocity * DirectionRightHand);

        LeftFoot.rotation = Quaternion.Euler((int)LeftFootAngle, 0, 0);
        RightFoot.rotation = Quaternion.Euler((int)RightFootAngle, 0, 0);
        LeftHand.rotation = Quaternion.Euler((int)LeftHandAngle, 0, 0);
        RightHand.rotation = Quaternion.Euler((int)RightHandAngle, 0, 0);

        FootAngleRange += AngularVelocity;

    }
}
