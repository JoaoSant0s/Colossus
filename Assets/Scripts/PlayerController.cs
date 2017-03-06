using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	
	[SerializeField]
	private float speed = 1f;
	[SerializeField]
	private float lookSensitivity = 3f;
    [SerializeField]
    private float thrusterForce = 2000f;

    [SerializeField]
    private float jumpTimeOffset = 0.5f;

    [Header("Spring Settings")]
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;

    private PlayerMotor motor;
    private ConfigurableJoint joint;
    private bool isGround;    
    

    void Start(){
        joint = GetComponent<ConfigurableJoint>();
        motor = GetComponent<PlayerMotor>();
        isGround = true;
        SetJointSettings(jointSpring);
    }
	
	void Update(){
		Move();
		RotationPlayer();
		RotationCamera();
        ThrusterForce();
    }

    void SetJointSettings(float _jointSpring) {
        joint.yDrive = new JointDrive {
            positionSpring = _jointSpring,
            maximumForce = jointMaxForce
        };
    }
    
    void Move() {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);
    }

    void RotationPlayer() {

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.RotationPlayer(_rotation);
    }

    void RotationCamera() {
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _rotationCameraX = _xRot * lookSensitivity;

        motor.RotationCamera(_rotationCameraX);
    }

    void ThrusterForce() {
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButtonDown("Jump") && isGround) {
            isGround = false;
            _thrusterForce = Vector3.up * thrusterForce;   
        }

        motor.ApplyThrusterForce(_thrusterForce);
    }  

    void OnTriggerStay(Collider other) {
        if(other.gameObject.layer == (LayerMask.NameToLayer("Ground")) && !isGround) isGround = true;
    }

}