using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;

public class SensorDataTracker : MonoBehaviour
{
    public InputActionProperty leftHandPos;
    public InputActionProperty rightHandPos;

    public bool isRecording;
    public List<(float time, Vector3 leftHandPos, Vector3 rightHandPos)> currentRecording = new();

    void Update()
    {
        isRecording = GetComponent<XRGrabInteractable>().isSelected;

        if (isRecording) 
            recordData();
        else 
            if (currentRecording.Count != 0) // save and reset if the recording ends
            {
                SaveToFile();
                currentRecording = new(); // reset recording
            }
    }

    public void recordData()
    {
        // add timestamp and hand positons (relative) to current recording list
        currentRecording.Add((
            Time.time,
            leftHandPos.action.ReadValue<Vector3>(),
            rightHandPos.action.ReadValue<Vector3>()));
    }

    public string ToCSV()
    {
        var sb = new System.Text.StringBuilder("time,leftHandPosX,leftHandPosY,leftHandPosZ,rightHandPosX,rightHandPosY,rightHandPosZ");
        foreach (var frame in currentRecording)
        {
            sb.Append('\n').
                Append(frame.time.ToString()).Append(',').
                Append(frame.leftHandPos.x.ToString()).Append(',').
                Append(frame.leftHandPos.y.ToString()).Append(',').
                Append(frame.leftHandPos.z.ToString()).Append(',').
                Append(frame.rightHandPos.x.ToString()).Append(',').
                Append(frame.rightHandPos.y.ToString()).Append(',').
                Append(frame.rightHandPos.z.ToString());
        }
        return sb.ToString();
    }

    public void SaveToFile()
    {
        var content = ToCSV();

        //var folder = Application.persistentDataPath;
        var folder = Application.streamingAssetsPath;
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        var filePath = Path.Combine(folder, "currentRecording.csv");

        File.WriteAllText(filePath, content);

        Debug.Log($"CSV file written to \"{filePath}\"");
    }
}
