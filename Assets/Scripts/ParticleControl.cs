using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleControl : MonoBehaviour
{
    VisualEffect visualEffect;
    MyMessageListener shoulderData;
    Timer timerGatheringL;
    Timer timerGatheringR;
    Timer timerSpreadingL;
    Timer timerSpreadingR;

    [SerializeField]
    int tensionSpeed = 50;

    [SerializeField]
    int relaxationSpeed = 100;

    [SerializeField]
    int upperLimit = 200;

    [SerializeField]
    int lowerLimit = 2500;

    [SerializeField]
    float tensionThreshold = 0.6f;

    [SerializeField]
    int tensionTime = 3;


    int enableLeftGathering = 0;
    int enableRightGathering = 0;

    bool leftTurnStart = true;




    // Start is called before the first frame update
    void Start()
    {
        visualEffect = this.GetComponent<VisualEffect>();
        shoulderData = GameObject.Find("SerialController").GetComponent<MyMessageListener>();
        timerGatheringL = GameObject.Find("[CameraRig]").GetComponent<Timer>();
        timerGatheringR = GameObject.Find("[CameraRig]").GetComponent<Timer>();
        timerSpreadingL = GameObject.Find("[CameraRig]").GetComponent<Timer>();
        timerSpreadingR = GameObject.Find("[CameraRig]").GetComponent<Timer>();

        visualEffect.SetInt("Min", lowerLimit);
        visualEffect.SetInt("Max", upperLimit);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float shoulderLeft;
        float shoulderRight;
        shoulderLeft = Mathf.Round((float)shoulderData.left * 100f) / 100f;
        shoulderRight = Mathf.Round((float)shoulderData.right * 100f) / 100f;
        visualEffect.SetFloat("ParticleAmountLeft", shoulderLeft);
        visualEffect.SetFloat("ParticleAmountRight", shoulderRight);

        visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);
        visualEffect.SetInt("EnableRightGathering", enableRightGathering);

        //Debug.Log("222");

        //if (shoulderLeft >= tensionThreshold && timerGatheringL.TimerStart == false)
        //{
        //    timerGatheringL.TimerStart = true;
        //    enableLeftGathering = 5;
        //    visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);

        //    if (timerGatheringL.CurrentTime >= tensionTime)
        //    {
        //        timerGatheringL.TimerStart = false;
        //        enableLeftGathering = 0;
        //        visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);
        //        timerGatheringL.ResetTimer();
        //    }
        //}
        //else
        //{
        //    timerGatheringL.TimerStart = false;
        //    enableLeftGathering = 0;
        //    visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);
        //    timerGatheringL.ResetTimer();
        //}

        Debug.Log(timerGatheringL.CurrentTime);

        if (shoulderLeft >= tensionThreshold && timerGatheringL.TimerStart == false && leftTurnStart == true)
        {

            timerGatheringL.TimerStart = true;
            enableLeftGathering = 5;
            visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);
            Debug.Log("33333");
        }
        else
        {
            timerGatheringL.TimerStart = false;
            enableLeftGathering = 0;
            visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);
        }

        if (timerGatheringL.CurrentTime >= tensionTime && timerGatheringL.TimerStart == true)
        {

            enableLeftGathering = 0;
            visualEffect.SetInt("EnableLeftGathering", enableLeftGathering);
            timerGatheringL.ResetTimer();
            leftTurnStart = false;
            Debug.Log("22222");
        }




    }
}
