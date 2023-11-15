using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateSource: MonoBehaviour
{
    public GameObject platePrefab;

    public void SpawnPlate(SelectEnterEventArgs args)
    {
        GameObject plate = Instantiate(platePrefab, transform.position + Vector3.up, Quaternion.identity, transform.parent);

        GetComponent<XRSimpleInteractable>().interactionManager.SelectEnter(
            GetComponent<XRSimpleInteractable>().interactorsSelecting[0],
            plate.GetComponent<XRGrabInteractable>());

        Debug.Log(args.interactorObject);
    }
}
