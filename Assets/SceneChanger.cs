using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string targetSceneName = "Room";

        if (Input.GetKeyDown(KeyCode.L) && SceneManager.GetActiveScene().name != targetSceneName)
            SceneManager.LoadScene(targetSceneName);
    }
}
