using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EggSource : MonoBehaviour
{
    public GameObject eggPrefab;

    public void SpawnEgg()
    {
        GameObject egg = Instantiate(eggPrefab, transform.position + Vector3.up, Quaternion.identity, transform.parent);

        GetComponent<XRSimpleInteractable>().interactionManager.SelectEnter(
            GetComponent<XRSimpleInteractable>().interactorsSelecting[0], 
            egg.GetComponent<XRGrabInteractable>());
    }
}