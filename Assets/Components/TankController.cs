using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankController : MonoBehaviour
{

    public Tank tank;
    public LeverGrabber[] grabbers;

    public float leverBound;

    public Transform leverMoveFB;
    public Transform leverTurnLR;
    public Transform leverTurretLR;
    public Transform leverTurretUD;
  
    private Transform[] levers;

    // Use this for initialization
    void Start()
    {

        List<Transform> leversMut = new List<Transform>();

        leversMut.Add(leverMoveFB);
        leversMut.Add(leverTurnLR);
        leversMut.Add(leverTurretLR);
        leversMut.Add(leverTurretUD);

        levers = leversMut.ToArray();

        
    }



    // Update is called once per frame
    void Update()
    {

        foreach (LeverGrabber grabber in grabbers)
        {
            Transform[] leversGrabbed = grabber.GetLeversGrabbed();

            foreach (Transform lever in leversGrabbed)
            {
                Vector3 leverLocalPositionOld = lever.localPosition;
                lever.localPosition = grabber.transform.localPosition;
                Vector3 leverLocalPositionNew = lever.localPosition;

                leverLocalPositionNew.z = Mathf.Clamp(lever.localPosition.z, -leverBound, leverBound);
                leverLocalPositionNew.x = leverLocalPositionOld.x;
                leverLocalPositionNew.y = leverLocalPositionOld.y;
                Debug.Log(leverLocalPositionNew.z);
                lever.localPosition = leverLocalPositionNew;
            }
        }


        if (grabbers[1].makeTankMove == true)
        {
            tank.Move(GetLeverIntensity(leverMoveFB));
            tank.Turn(GetLeverIntensity(leverTurnLR));
            tank.TurnTurret(GetLeverIntensity(leverTurretUD), GetLeverIntensity(leverTurretLR));
        }
    }


    private float GetLeverIntensity(Transform lever)
    {
        return lever.localPosition.z / leverBound;
    }
}