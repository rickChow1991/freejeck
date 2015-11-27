using UnityEngine;

namespace com.iuixi.FreeJeck
{
	public class FllowCamera : MonoBehaviour
	{
		public Transform target = null;
		private IFllowTarget targetController;
		public float height = 0.244f;
		public float positionDamping = 3f;
		public float velocityDamping = 3f;
		public float distance = 1.2f;
		private float maxDistance = 2f;
		public LayerMask ignoreLayers = -1;
		public float rotationDamping = 10.0f;
		public float cameraRorationY = 120.0f;
		private Vector3 prevVelocity = Vector3.zero;
		public bool smoothRotation = true;
		private float speedFactor;
		private float currentDistance;
		private Vector3 currentVelocity = Vector3.zero;
		//当前速度
		private Vector3 newTargetPosition;
		public bool isSkillJump = false;

		void Start ()
		{
			targetController = target.GetComponent<IFllowTarget> ();
		}

		void FixedUpdate ()
		{
			//在若干秒（damping)内 从之前的速度值变换到物体当前的速度）
			currentVelocity = Vector3.Lerp (prevVelocity, targetController.GetCurrentSpeed () * Vector3.forward, velocityDamping * Time.deltaTime);
			currentVelocity.y = 0;//忽略Y轴的速度
			prevVelocity = currentVelocity;

		}

		void Update ()
		{

			if (smoothRotation) {
				Quaternion wantedRotation = Quaternion.LookRotation (target.position - transform.position, target.up);
				wantedRotation.x = 0f;
				wantedRotation.z = 0f;
				if (!isSkillJump)
					transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
			}
		}

		void LateUpdate ()
		{
			speedFactor = Mathf.Clamp01 (targetController.GetCurrentSpeed () / targetController.GetMaxSpeed ()); //返回0-1之间的值（获取物体的移动速度向量
			//        GetComponent<Camera>().fieldOfView = Mathf.Lerp(32, 60, speedFactor * Time.deltaTime);
			if (targetController.GetCurrentSpeed () >= 0) {
				if (!targetController.GetIsDrift ())
					currentDistance = Mathf.Lerp (distance, maxDistance, speedFactor);

			} else {
				currentDistance = Mathf.Lerp (distance, 0.4f, targetController.GetCurrentSpeed () / -3.0f);
			}
			currentVelocity = currentVelocity.normalized;

			if (isSkillJump)
				currentDistance = 1f;
			newTargetPosition = target.TransformPoint (0, currentDistance >= distance ? Mathf.Lerp (height - 0.3f, height, speedFactor) : height - 0.3f, -currentDistance);
			transform.position = Vector3.Lerp (transform.position, newTargetPosition, Time.deltaTime * rotationDamping);


		}
	}
}