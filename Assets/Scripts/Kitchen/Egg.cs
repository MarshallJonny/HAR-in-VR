using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool IsCracked { get; private set; } = false;
    public Material crackedMaterial;
    private void OnCollisionEnter(Collision collision)
    {
        if (!IsCracked && !collision.gameObject.CompareTag("DoesntCrackEgg"))
        {
            IsCracked = true;
            GetComponent<MeshRenderer>().material = crackedMaterial;
            Debug.Log("cracking egg with " + collision.gameObject.name);
        }
    }
}
