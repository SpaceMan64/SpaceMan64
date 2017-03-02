using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using UnityEngine.UI;

public class FlightController : MonoBehaviour
{
	Controller flyController;
	GestureRecogniser gestureRecogniser;
	public GameObject vehicle;
	float rotateAngleX;
	float rotateAngleZ;
	float rateOfChange = 0.00058f;
	float topRot = 1.0f;
	float currentMaxSpeed = 20.0f;
	float topSpeed = 20.0f;
	float nitrosSpeed;
	float speed = 0.0f;
	float acceleration = 0.07f;
	float handling = 40.0f;
	Vector3 velocity = new Vector3(0.0f,0.0f,0.0f);

    public UnityEngine.UI.Image speedBar;

	// Use this for initialization
	void Start()
	{
		//Initalise flight controller
		flyController = new Controller();
		nitrosSpeed = topSpeed * 2.0f;
		gestureRecogniser = GetComponent<GestureRecogniser>(); 
		rotateAngleX = 0.0f;
		rotateAngleZ = 0.0f;


	}


	void Update()
	{
		System.Collections.Generic.List<Leap.Hand> hands = gestureRecogniser.getFrameHands();
		if (hands.Count == 2) {
			string current_gesture = gestureRecogniser.Recognise(hands[1]);
			string for_ui = gestureRecogniser.Recognise(hands[0]);
			Leap.Hand r_hand = hands [1];

			if (for_ui == "FIST") {
				topSpeed = nitrosSpeed;
			} else {
				topSpeed = currentMaxSpeed;
			}
			if (r_hand != null) {

				float RollAngle = r_hand.PalmNormal.Roll;
				float PitchAngle = r_hand.Direction.Pitch;
				Tilt (RollAngle);
				Rise (PitchAngle);
			}

<<<<<<< HEAD
			velocity = vehicle.transform.forward * speed * Time.deltaTime;
			vehicle.transform.position += velocity;
			Debug.Log ("Speed :" + speed);
			if (speed <= topSpeed) {
				Debug.Log ("Making it to increase speed");
				speed += acceleration;
			}
		}
=======
			//Added slipperiness to flight, to make it more natural
			velocity = (velocity.normalized + (vehicle.transform.forward) / (handling * 1.5f) ) * speed * Time.deltaTime;
		}

		vehicle.transform.position += velocity;
		speed *= .99f;
		if (speed <= topSpeed) {
			Debug.Log ("Making it to increase speed");
			speed += acceleration;
		}


>>>>>>> 25dd6d54707ed055c7eda9b12bd91dc50094aa7c

        speedBar.fillAmount = speed / topSpeed;
	}

	bool Tilt(float Roll)
	{

		if (Roll > 0.0f) {
			if (Roll > 1.0f && Roll < 2.0f) {
				Quaternion targetRotation = Quaternion.AngleAxis((1.0f * Mathf.Sign (Roll)), Vector3.up);
				vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation , vehicle.transform.rotation *= targetRotation, handling * Time.deltaTime);
				return true;
			}
		} else {
			if(Roll > -2.4f && Roll < -1.5f){
				Quaternion targetRotation = Quaternion.AngleAxis((1.0f * Mathf.Sign (Roll)), Vector3.up);
				vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation , vehicle.transform.rotation *= targetRotation, handling * Time.deltaTime);
				return true;
			}

		}

		return false;
	}
	void Rise(float Pitch)
	{
		float direction = 1.0f;
		if (Pitch > 1.6f) {
			direction *= -1;
			Quaternion targetQuat = Quaternion.AngleAxis (direction, Vector3.left);
			vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation, vehicle.transform.rotation *= targetQuat, handling * Time.deltaTime);
		} else if (Pitch < 0.5f) {
			Quaternion targetQuat = Quaternion.AngleAxis (direction, Vector3.left);
			vehicle.transform.rotation = Quaternion.Slerp(vehicle.transform.rotation, vehicle.transform.rotation *= targetQuat, handling * Time.deltaTime);
		}

	}
}
