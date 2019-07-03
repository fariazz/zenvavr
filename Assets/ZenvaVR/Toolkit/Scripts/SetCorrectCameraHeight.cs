using UnityEngine;
using UnityEngine.XR;

// This script was created by Unity
// we've added a namespace to prevent naming conflicts
namespace Zenva.VR
{
    public class SetCorrectCameraHeight : MonoBehaviour
    {
        enum TrackingSpace
        {
            Stationary,
            RoomScale
        }

        [Header("Camera Settings")]

        [SerializeField]
        [Tooltip("Decide if experience is Room Scale or Stationary. Note this option does nothing for mobile VR experiences, these experience will default to Stationary")]
        TrackingSpace m_TrackingSpace = TrackingSpace.Stationary;

        [SerializeField]
        [Tooltip("Camera Height - overwritten by device settings when using Room Scale ")]
        float m_StationaryCameraYOffset = 1.36144f;

        [SerializeField]
        [Tooltip("GameObject to move to desired height off the floor (defaults to this object if none provided)")]
        GameObject m_CameraFloorOffsetObject;

        void Awake()
        {
            if (!m_CameraFloorOffsetObject)
            {
                Debug.LogWarning("No camera container specified for VR Rig, using attached GameObject");
                m_CameraFloorOffsetObject = this.gameObject;
            }

        }

        void Start()
        {
            SetCameraHeight();
        }

        void SetCameraHeight()
        {
            float cameraYOffset = m_StationaryCameraYOffset;

            if (m_TrackingSpace == TrackingSpace.Stationary)
            {
                XRDevice.SetTrackingSpaceType(TrackingSpaceType.Stationary);

                // make the user face to the forward direction
                InputTracking.Recenter();
            }

            // if on a room-scale experience, we disregard the height the user entered
            else if (m_TrackingSpace == TrackingSpace.RoomScale)
            {
                if (XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale))
                    cameraYOffset = 0;
            }

            //Move floor offset to correct height
            if (m_CameraFloorOffsetObject)
                m_CameraFloorOffsetObject.transform.localPosition = new Vector3(m_CameraFloorOffsetObject.transform.localPosition.x, cameraYOffset, m_CameraFloorOffsetObject.transform.localPosition.z);
        }
    }
}
