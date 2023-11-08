using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSensor : MonoBehaviour
{
    public TMPro.TextMeshProUGUI display;
    public Material on;
    Material off;

    private void Start()
    {
        off = GetComponent<MeshRenderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Plate collided with " + collision.gameObject.name);
        GetComponent<MeshRenderer>().material = on;
        display.text = collision.gameObject.name;
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<MeshRenderer>().material = off;
        display.text = "";
    }
}
