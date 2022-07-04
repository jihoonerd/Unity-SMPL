using UnityEngine;
using Newtonsoft.Json;


public class MotionController : MonoBehaviour
{
    public TextAsset jsonFile;
    int motionLength;
    MotionData motionData;


    void Start()
    {
        motionData = ReadFromJSON(jsonFile.text); // Read the JSON file
        motionLength = motionData.translation.Length;
        
        Debug.Log(motionData.label);
        Debug.Log(motionData.translation[0][0]);

        // StartCoroutine(RunMotion());
    }

    // IEnumerator RunMotion()
    // {
    //     // yield return new WaitForSeconds(1.0f);
    //     while(dataReader.GetCurIndex() < dataReader.numFiles)
    //     {
    //         yield return new WaitForSeconds(frameInterval);
    //         MotionData motionData = dataReader.GetMotionData();
    //         SetPose(motionData, baseRig);
    //     }
    // }

    MotionData ReadFromJSON(string jsonContents)
    {   
        MotionData motionData = JsonConvert.DeserializeObject<MotionData>(jsonContents);
        return motionData;
    }
}