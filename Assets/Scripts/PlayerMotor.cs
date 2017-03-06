using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotationPlayer = Vector3.zero;
	private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;
    
    [SerializeField]
	private Camera cam;
	private Rigidbody rb;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
	}
	 
	void FixedUpdate(){
		PerformMovement();
        PerformRotation();
	}
	
	void PerformRotation(){
		PerformRotationPlayer();
		PerformRotationCamera();
	}
	
	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}
	
	public void RotationPlayer(Vector3 _rotation){
		rotationPlayer = _rotation;
	}
	
	public void RotationCamera(float _cameraRotationX) {
        cameraRotationX = _cameraRotationX;
	}
    public void ApplyThrusterForce(Vector3 _thrusterForce) {
        thrusterForce = _thrusterForce;
    }


    void PerformRotationCamera(){
		if(cam != null){
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
		}
	}
	
	void PerformRotationPlayer(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationPlayer ));
	}
	
	void PerformMovement(){
		if(velocity != Vector3.zero){
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}

        if(thrusterForce != Vector3.zero) {
            rb.AddForce(thrusterForce, ForceMode.Acceleration);
        }
	}    
}