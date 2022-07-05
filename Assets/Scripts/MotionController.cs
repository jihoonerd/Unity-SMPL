using UnityEngine;
using System.Collections;
using Newtonsoft.Json;


public class MotionController : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject skeleton;
    public float fps = 20.0f;
    int motionLength;
    MotionData motionData;
    string label;
    float[][] translation;
    float[][][] rotationQuat;
    string quaternionOrder;
    float guidanceScale;
    GameObject baseModel;

    SMPLRig smplRig;    

    void Start()
    {
        motionData = ReadFromJSON(jsonFile.text); // Read the JSON file
        motionLength = motionData.translation.Length;
        label = motionData.label;
        translation = motionData.translation;
        rotationQuat = motionData.rotation_quat;
        quaternionOrder = motionData.quaternion_order;
        guidanceScale = motionData.guidance_scale;

        smplRig = new SMPLRig(Instantiate(skeleton));
        StartCoroutine(RunMotion());
    }

    IEnumerator RunMotion()
    {
        // yield return new WaitForSeconds(1.0f);
        for (int frameInd = 0 ; frameInd < motionLength; frameInd++)
        {
            yield return new WaitForSeconds(1/fps);
            smplRig.SetPose(translation, rotationQuat, frameInd);
        }
    }

    MotionData ReadFromJSON(string jsonContents)
    {   
        MotionData motionData = JsonConvert.DeserializeObject<MotionData>(jsonContents);
        return motionData;
    }

    
}