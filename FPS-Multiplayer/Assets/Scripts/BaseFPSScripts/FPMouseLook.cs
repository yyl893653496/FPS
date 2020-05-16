using System;
using Scripts;
using Scripts.Weapon;
using UnityEngine;

public class FPMouseLook : MonoBehaviour
{
    public float MouseSensitivity;
    public Transform characterTransform;
    public Vector2 MaxminAngle;

    private Transform cameraTransform;
    private Vector3 cameraRotation;


    public AnimationCurve RecoilCurve;
    public Vector2 RecoilRange;

    public float RecoilFadeOutTime = 0.3f;
    private float currentRecoilTime;
    private Vector2 currentRecoil;
    private CameraSpring cameraSpring;    

    private void Start()
    {
        cameraTransform = transform;
        cameraSpring = GetComponentInChildren<CameraSpring>();

    }

    void Update()
    {
        var tmp_MouseX = Input.GetAxis("Mouse X");
        var tmp_MouseY = Input.GetAxis("Mouse Y");


        cameraRotation.y += tmp_MouseX * MouseSensitivity;
        cameraRotation.x -= tmp_MouseY * MouseSensitivity;


        CalculateRecoilOffset();
        

        cameraRotation.y += currentRecoil.y;
        cameraRotation.x -= currentRecoil.x;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, MaxminAngle.x, MaxminAngle.y);
        characterTransform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
        cameraTransform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
    }


    private void CalculateRecoilOffset()
    {
        currentRecoilTime += Time.deltaTime;
        float tmp_RecoilFraction = currentRecoilTime / RecoilFadeOutTime;
        float tmp_RecoilValue = RecoilCurve.Evaluate(tmp_RecoilFraction);
        currentRecoil = Vector2.Lerp(Vector2.zero, currentRecoil, tmp_RecoilValue);
    }


    public void FiringForTest()
    {
        currentRecoil += RecoilRange;
        cameraSpring.StartCameraSpring();
        currentRecoilTime = 0;
    }
}