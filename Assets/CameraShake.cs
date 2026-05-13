using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDecayStart = 0.002f;
    public float shakeIntensityStart = 0.03f;

    float shakeDecay;
    float shakeIntensity;

    Vector3 originPosition;
    Quaternion originRotation;
    bool shaking;
    Transform transformAtOrigin;

    void OnEnable()
    {
        transformAtOrigin = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!shaking)
            return;
        if (shakeIntensity > 0f)
        {
            transformAtOrigin.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
            transformAtOrigin.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
                originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
                originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
                originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * .2f);
            shakeIntensity -= shakeDecay;
        }
        else
        {
            shaking = false;
            transformAtOrigin.localPosition = originPosition;
            transformAtOrigin.localRotation = originRotation;
        }
    }

    public void Shake()
    {
        if (!shaking)
        {
            originPosition = transformAtOrigin.localPosition;
            originRotation = transformAtOrigin.localRotation;
        }
        shaking = true;
        shakeDecay = shakeDecayStart;
        shakeIntensity = shakeIntensityStart;
    }



}
