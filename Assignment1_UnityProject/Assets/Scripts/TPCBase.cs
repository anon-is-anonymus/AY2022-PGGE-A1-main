using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
	// The base class for all third-person camera controllers
	public abstract class TPCBase
	{
		protected Transform mCameraTransform;
		protected Transform mPlayerTransform;

		public Transform CameraTransform
		{
			get
			{
				return mCameraTransform;
			}
		}
		public Transform PlayerTransform
		{
			get
			{
				return mPlayerTransform;
			}
		}

		public TPCBase(Transform cameraTransform, Transform playerTransform)
		{
			mCameraTransform = cameraTransform;
			mPlayerTransform = playerTransform;
		}

		public void RepositionCamera()
		{
			float distance;
			//minDistance set to 0 so if the player is straight in front of the wall,
			//the camera will never clip through the wall
			float minDistance = 0f;
			float maxDistance = 4f;
			//dollyDir used to get the direction the cam is facing, normalized to get a 1 value
			//the 1 value is then used to calculate desiredCameraPos, using the 1 value * max dist,
			//we can get the ideal camera position as it would face the same direction only the distance changes
			Vector3 dollyDir = mCameraTransform.localPosition.normalized;
			//TransformPoint() used as world position is needed to see where in the world the raycast should end
			Vector3 desiredCameraPos = mCameraTransform.TransformPoint(dollyDir * maxDistance);
			RaycastHit hit;

			if (Physics.Linecast(mCameraTransform.transform.position, desiredCameraPos, out hit))
			{
				//MathF.Clamp() used to ensure that camera will never go past maxDistance or minDistance
				distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
			}
			else
			{
				distance = maxDistance;
			}

			//lerp used to make sure shift is smooth, same with deltatime
			//deltatime is multiplied by 4 to ensure that the camera wil not phase through objects
			mCameraTransform.localPosition = Vector3.Lerp(mCameraTransform.localPosition, dollyDir * distance, Time.deltaTime * 4);
		}

		public abstract void Update();
	}
}

