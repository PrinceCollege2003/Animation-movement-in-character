using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController player;
    private float sensitivity = 500f;
    private float clampAngle = 85f;

    private float verticalRotation;
    private float horizontalRotation;

    void Start()
    {
        this.verticalRotation = this.transform.localEulerAngles.x;
        this.horizontalRotation = this.transform.eulerAngles.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Debug.DrawRay(this.transform.position, this.transform.forward * 2, Color.red);
        
    }

    private void Look()
    {
        float mouseVertical = -Input.GetAxis("Mouse Y");
        float mouserHorizontal = Input.GetAxis("Mouse X");

        this.verticalRotation += mouseVertical * this.sensitivity * Time.deltaTime;
        this.horizontalRotation += mouserHorizontal * this.sensitivity * Time.deltaTime;

        this.verticalRotation = Mathf.Clamp(this.verticalRotation, -this.clampAngle, this.clampAngle);

        this.transform.localRotation = Quaternion.Euler(this.verticalRotation, 0f, 0f);
        this.player.transform.rotation = Quaternion.Euler(0f, this.horizontalRotation, 0f);
    }
}
