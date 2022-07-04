using UnityEngine;
using Newtonsoft.Json;


public class MotionController : MonoBehaviour
{
    public TextAsset jsonFile;
    MotionData motionData;


    void Start()
    {
        motionData = ReadFromJSON(jsonFile.text);
        Debug.Log(motionData.label);
        Debug.Log(motionData.translation[0][0]);
    }


    MotionData ReadFromJSON(string jsonContents)
    {   
        MotionData motionData = JsonConvert.DeserializeObject<MotionData>(jsonContents);
        return motionData;
    }
}