using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SpatialTracking;

namespace Zenva.VR
{
    public class AutoPoseSource : MonoBehaviour
    {
        private TrackedPoseDriver trackedPoseDriver;
        private AxisController axisController;
        private ButtonController buttonController;

        // how often do we check the controller?
        private readonly float checkRate = 0.5f;

        void Awake ()
        {
            // get the components
            trackedPoseDriver = GetComponent<TrackedPoseDriver>();
            axisController = GetComponent<AxisController>();
            buttonController = GetComponent<ButtonController>();
        }

        void Start ()
        {
            // call the CheckControllerPoseSource function every 'checkRate' seconds
            InvokeRepeating("CheckControllerPoseSource", 0.0f, checkRate);
        }

        void CheckControllerPoseSource ()
        {
            // get a list of all connected controllers
            List<InputDevice> devices = new List<InputDevice>();

            // loop through each device and change the pose source
            for(int i = 0; i < devices.Count; i++)
            {
                if(devices[i].role == InputDeviceRole.LeftHanded)
                {
                    ChangePoseSource(InputDeviceRole.LeftHanded);
                }
                else if(devices[i].role == InputDeviceRole.RightHanded)
                {
                    ChangePoseSource(InputDeviceRole.RightHanded);
                }
            }
        }

        // changes the device's role to either left or right handed
        void ChangePoseSource (InputDeviceRole deviceRole)
        {
            trackedPoseDriver.SetPoseSource(TrackedPoseDriver.DeviceType.GenericXRController, 
                deviceRole == InputDeviceRole.LeftHanded ? TrackedPoseDriver.TrackedPose.LeftPose : TrackedPoseDriver.TrackedPose.RightPose);

            axisController.deviceRole = deviceRole;
            buttonController.deviceRole = deviceRole;
        }
    }
}