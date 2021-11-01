using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform camTransofrm;
    private float shakeeDur = 1f, shakeAmount = 0.04f, decreaseFactor = 1.5f;

    private Vector3 originPos;

    private void Start()
    {
        camTransofrm = GetComponent<Transform>();
        originPos = camTransofrm.localPosition;
    }

    private void Update()
    {
        if(shakeeDur > 0)
        {
            camTransofrm.localPosition = originPos + Random.insideUnitSphere * shakeAmount;
            shakeeDur -= Time.deltaTime * decreaseFactor;
        } else
        {
            shakeeDur = 0;
            camTransofrm.localPosition = originPos;
        }
    }
}
