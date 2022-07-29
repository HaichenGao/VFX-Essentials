using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleControl : MonoBehaviour
{
    VisualEffect visualEffect;

    //int particleAmountLeft;

    //int particleAmountRight;

    [SerializeField]
    int tensionSpeed = 50;

    [SerializeField]
    int relaxationSpeed = 100;

    [SerializeField]
    int upperLimit = 200;

    [SerializeField]
    int lowerLimit = 2500;

    int enableLeft = 5;
    int enableRight = 5;

    //bool flagq = false;
    //bool flagw = false;

    MyMessageListener shoulderData;


    // Start is called before the first frame update
    void Start()
    {
        visualEffect = this.GetComponent<VisualEffect>();
        shoulderData = GameObject.Find("SerialController").GetComponent<MyMessageListener>();
        //particleAmountLeft = lowerLimit;
        //particleAmountRight = lowerLimit;
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

        visualEffect.SetInt("EnableLeft", enableLeft);
        visualEffect.SetInt("EnableRight", enableRight);
        
    }
}
