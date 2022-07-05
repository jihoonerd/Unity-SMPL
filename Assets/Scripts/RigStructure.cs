using UnityEngine;

public class SMPLRig
{
    public GameObject Pelvis { get; set; }
    
    public GameObject LHip { get; set; }
    public GameObject LKnee { get; set; }
    public GameObject LAnkle { get; set; }
    public GameObject LFoot { get; set; }

    public GameObject RHip { get; set; }
    public GameObject RKnee { get; set; }
    public GameObject RAnkle { get; set; }
    public GameObject RFoot { get; set; }

    public GameObject Spine1 { get; set; }
    public GameObject Spine2 { get; set; }
    public GameObject Spine3 { get; set; }
    
    public GameObject LCollar { get; set; }
    public GameObject LShoulder { get; set; }
    public GameObject LElbow { get; set; }
    public GameObject LWrist { get; set; }
    public GameObject LHand { get; set; }

    public GameObject Neck { get; set; }
    public GameObject Head { get; set; }

    public GameObject RCollar { get; set; }
    public GameObject RShoulder { get; set; }
    public GameObject RElbow { get; set; }
    public GameObject RWrist { get; set; }
    public GameObject RHand { get; set; }

    public SMPLRig(GameObject model)
    {
        Pelvis = model.transform.Find("m_avg_root/m_avg_Pelvis").gameObject;
        LHip = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_L_Hip").gameObject;
        LKnee = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_L_Hip/m_avg_L_Knee").gameObject;
        LAnkle = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_L_Hip/m_avg_L_Knee/m_avg_L_Ankle").gameObject;
        LFoot = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_L_Hip/m_avg_L_Knee/m_avg_L_Ankle/m_avg_L_Foot").gameObject;
        RHip = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_R_Hip").gameObject;
        RKnee = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_R_Hip/m_avg_R_Knee").gameObject;
        RAnkle = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_R_Hip/m_avg_R_Knee/m_avg_R_Ankle").gameObject;
        RFoot = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_R_Hip/m_avg_R_Knee/m_avg_R_Ankle/m_avg_R_Foot").gameObject;
        Spine1 = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1").gameObject;
        Spine2 = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2").gameObject;
        Spine3 = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3").gameObject;
        LCollar = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_L_Collar").gameObject;
        LShoulder = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_L_Collar/m_avg_L_Shoulder").gameObject;
        LElbow = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_L_Collar/m_avg_L_Shoulder/m_avg_L_Elbow").gameObject;
        LWrist = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_L_Collar/m_avg_L_Shoulder/m_avg_L_Elbow/m_avg_L_Wrist").gameObject;
        LHand = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_L_Collar/m_avg_L_Shoulder/m_avg_L_Elbow/m_avg_L_Wrist/m_avg_L_Hand").gameObject;
        Neck = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_Neck").gameObject;
        Head = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_Neck/m_avg_Head").gameObject;
        RCollar = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_R_Collar").gameObject;
        RShoulder = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_R_Collar/m_avg_R_Shoulder").gameObject;
        RElbow = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_R_Collar/m_avg_R_Shoulder/m_avg_R_Elbow").gameObject;
        RWrist = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_R_Collar/m_avg_R_Shoulder/m_avg_R_Elbow/m_avg_R_Wrist").gameObject;
        RHand = model.transform.Find("m_avg_root/m_avg_Pelvis/m_avg_Spine1/m_avg_Spine2/m_avg_Spine3/m_avg_R_Collar/m_avg_R_Shoulder/m_avg_R_Elbow/m_avg_R_Wrist/m_avg_R_Hand").gameObject;
    }

    public void SetPose(float[][] translation, float[][][] rotationQuat, int frameInd){
        Vector3 rootPos = new Vector3(translation[frameInd][0], translation[frameInd][1], translation[frameInd][2]);
        Pelvis.transform.position = rootPos;

        float[][] quaternionData = rotationQuat[frameInd];  // rotationQuat[frameInd] -> (24, 4)
        Pelvis.transform.localRotation = SetLocalQuaternion(quaternionData[0]);
        LHip.transform.localRotation = SetLocalQuaternion(quaternionData[1]);
        LKnee.transform.localRotation = SetLocalQuaternion(quaternionData[4]);
        LAnkle.transform.localRotation = SetLocalQuaternion(quaternionData[7]);
        LFoot.transform.localRotation = SetLocalQuaternion(quaternionData[10]);
        RHip.transform.localRotation = SetLocalQuaternion(quaternionData[2]);
        RKnee.transform.localRotation = SetLocalQuaternion(quaternionData[5]);
        RAnkle.transform.localRotation = SetLocalQuaternion(quaternionData[8]);
        RFoot.transform.localRotation = SetLocalQuaternion(quaternionData[11]);
        Spine1.transform.localRotation = SetLocalQuaternion(quaternionData[3]);
        Spine2.transform.localRotation = SetLocalQuaternion(quaternionData[6]);
        Spine3.transform.localRotation = SetLocalQuaternion(quaternionData[9]);
        LCollar.transform.localRotation = SetLocalQuaternion(quaternionData[13]);
        LShoulder.transform.localRotation = SetLocalQuaternion(quaternionData[16]);
        LElbow.transform.localRotation = SetLocalQuaternion(quaternionData[18]);
        LWrist.transform.localRotation = SetLocalQuaternion(quaternionData[20]);
        LHand.transform.localRotation = SetLocalQuaternion(quaternionData[22]);
        Neck.transform.localRotation = SetLocalQuaternion(quaternionData[12]);
        Head.transform.localRotation = SetLocalQuaternion(quaternionData[15]);
        RCollar.transform.localRotation = SetLocalQuaternion(quaternionData[14]);
        RShoulder.transform.localRotation = SetLocalQuaternion(quaternionData[17]);
        RElbow.transform.localRotation = SetLocalQuaternion(quaternionData[19]);
        RWrist.transform.localRotation = SetLocalQuaternion(quaternionData[21]);
        RHand.transform.localRotation = SetLocalQuaternion(quaternionData[23]);
    }

    Quaternion SetLocalQuaternion(float[] localQuat){
        // Since Unity takes quaternion in the form of (x, y, z, w), we need to convert the quaternion to the form of (w, x, y, z)
        Quaternion quat = new Quaternion(localQuat[1], localQuat[2], localQuat[3], localQuat[0]);
        return quat;
    }
}