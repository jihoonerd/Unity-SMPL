using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class TrajectoryViewer : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject skeleton;
    public int interval = 1;
    public float fps = 20.0f;
    public bool identityRotEndJoints;
    public bool adjustTranslation;
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
    Vector3 adjustPos;

    // Start is called before the first frame update
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

        for (int i = 0; i < motionLength; i+=interval)
        {
            smplRig = new SMPLRig(Instantiate(skeleton));
            smplRig.avatar.GetComponentInChildren<SkinnedMeshRenderer>().material.SetColor("_Color", avatarColor);

            if (adjustTranslation)
            {
                adjustPos = new Vector3(basePos[0] + i / 20, basePos[1], basePos[2]);
                smplRig.SetPose(translation, rotationQuat, i, identityRotEndJoints, adjustPos, baseRot);
            }
            else
            {
                smplRig.SetPose(translation, rotationQuat, i, identityRotEndJoints, basePos, baseRot);
            }
        }
    }

    MotionData ReadFromJSON(string jsonContents)
    {   
        MotionData motionData = JsonConvert.DeserializeObject<MotionData>(jsonContents);
        return motionData;
    }
}
