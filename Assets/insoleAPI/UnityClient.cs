//using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class ZMQManager : MonoBehaviour
{
    private ZMQSubscriber subLeft;
    private ZMQSubscriber subRight;
    public float leftPressureData;
    public float leftPitchData;
    public float leftCentreData;
    public float rightPressureData;
    public float rightPitchData;
    public float rightCentreData;

    void Start()
    {
        subLeft = new ZMQSubscriber(1101);
        subRight = new ZMQSubscriber(1102);

        subLeft.OnMessageReceived += data =>
            leftPressureData = data[32];

        subLeft.OnMessageReceived += data =>
            leftCentreData = data[1];

        subLeft.OnMessageReceived += data =>
            leftPitchData = data[24];

        //right shoe
        subRight.OnMessageReceived += data =>
            rightPressureData = data[32];

        subRight.OnMessageReceived += data =>
            rightCentreData = data[1];

        subRight.OnMessageReceived += data =>
            rightPitchData = data[24];
    }

    void OnDestroy()
    {
        subLeft?.Stop();
        subRight?.Stop();
    }
}