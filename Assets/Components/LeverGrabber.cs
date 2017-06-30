using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(SteamVR_TrackedController))]
public class LeverGrabber : MonoBehaviour
{

    private SteamVR_TrackedController controller;
    private HashSet<Transform> leversInReach = new HashSet<Transform>();
    private List<Transform> leversGrabbed = new List<Transform>();
    public bool makeTankMove; 

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedController>();

        controller.TriggerClicked += Controller_TriggerClicked;
        controller.TriggerUnclicked += Controller_TriggerUnclicked;
    }

    private void Controller_TriggerClicked(object sender, ClickedEventArgs e)
    {
        leversGrabbed = leversInReach.ToList();
        makeTankMove = true; 
    }

    private void Controller_TriggerUnclicked(object sender, ClickedEventArgs e)
    {
        leversGrabbed.Clear();
        makeTankMove = false; 
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Lever"))
        {
            leversInReach.Add(col.transform);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Lever"))
        {
            leversInReach.Remove(col.transform);
        }
    }

    public Transform[] GetLeversGrabbed()
    {
        return leversGrabbed.ToArray();
    }
}