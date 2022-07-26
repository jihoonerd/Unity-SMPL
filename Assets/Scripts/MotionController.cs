using UnityEngine;
using System.Collections;
using Newtonsoft.Json;


public class MotionController : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject skeleton;
    public float fps = 20.0f;
    public bool identityRotEndJoints;
    public Color avatarColor = new Color(0.66f, 0.85f, 1.0f, 1.0f);
    int motionLength;
    MotionData motionData;
    string label;
    float[][] translation;
    float[][][] rotationQuat;
    string quaternionOrder;
    float guidanceScale;
    GameObject baseModel;

    SMPLRig smplRig;    
    Vector3 basePos;
    Vector3 baseRot;

    void Start()
    {
        motionData = ReadFromJSON(jsonFile.text); // Read the JSON file
        motionLength = motionData.translation.Length;
        label = motionData.label;
        translation = motionData.translation;
        rotationQuat = motionData.rotation_quat;
        quaternionOrder = motionData.quaternion_order;
        guidanceScale = motionData.guidance_scale;
        basePos = this.transform.position;
        baseRot = this.transform.eulerAngles;

        smplRig = new SMPLRig(Instantiate(skeleton));
        smplRig.avatar.GetComponentInChildren<SkinnedMeshRenderer>().material.SetColor("_Color", avatarColor);
        StartCoroutine(RunMotion());
    }

    IEnumerator RunMotion()
    {
        yield return new WaitForSeconds(0.5f);
        // yield return new WaitForSeconds(1.0f);
        for (int frameInd = 0 ; frameInd < motionLength; frameInd++)
        {
            yield return new WaitForSeconds(1/fps);
            smplRig.SetPose(translation, rotationQuat, frameInd, identityRotEndJoints, basePos, baseRot);
        }
    }

    MotionData ReadFromJSON(string jsonContents)
    {   
        MotionData motionData = JsonConvert.DeserializeObject<MotionData>(jsonContents);
        return motionData;
    }
}