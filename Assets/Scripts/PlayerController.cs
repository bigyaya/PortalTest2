using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float speed = 3f;
    [SerializeField] private float MouseSensitivityX = 3f;
    [SerializeField] private float MouseSensitivityY = 3f;

    #endregion



    #region Unity Lifecycle
    void Awake()
{

}

 void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

 void Update()
    {
        ////// calculer la vitesse du mouvement du joueur//////////
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        ///// calcule la rotation du joueur////////
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * MouseSensitivityX;

        motor.Rotate(rotation);

        ///// calcule la rotation due la caméra////////
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * MouseSensitivityY;

        motor.RotateCamera(cameraRotation);
    }

void FixedUpdate()
{

}
    #endregion



    #region Methods



    #endregion



    #region Private & Protected

    private PlayerMotor motor;

    #endregion
}
