using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public GameObject spiegelei;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Egg>() && !spiegelei.activeSelf)
        {
            if (other.gameObject.GetComponent<Egg>().IsCracked)
            {
                Debug.Log("Frying Egg");
                spiegelei.SetActive(true);
                Destroy(other.gameObject);
            }
            else Debug.Log("Crack the Egg First");
        }

        if (other.gameObject.GetComponent<Plate>() && spiegelei.activeSelf)
        {
            if (!other.transform.Find("Spiegelei").gameObject.activeSelf)
            {
                Debug.Log("Plating Egg");
                spiegelei.SetActive(false);
                other.transform.Find("Spiegelei").gameObject.SetActive(true);
            }
        }
    }
}
