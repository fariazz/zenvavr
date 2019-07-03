using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

namespace Zenva.VR
{
    public class ButtonController : MonoBehaviour
    {
        // Dictionary with available input mapping features
        static readonly Dictionary<string, InputFeatureUsage<bool>> availableFeatures = new Dictionary<string, InputFeatureUsage<bool>> {
            {"triggerButton", CommonUsages.triggerButton },
            {"gripButton", CommonUsages.gripButton },
            {"thumbrest", CommonUsages.thumbrest },
            {"primary2DAxisClick", CommonUsages.primary2DAxisClick },
            {"primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
            {"menuButton", CommonUsages.menuButton },
            {"secondaryButton", CommonUsages.secondaryButton },
            {"secondaryTouch", CommonUsages.secondaryTouch },
            {"primaryButton", CommonUsages.primaryButton },
            {"primaryTouch", CommonUsages.primaryTouch },
        };

        // list for user selection of the feature
        public enum FeatureOptions {
            triggerButton,
            gripButton,
            thumbrest,
            primary2DAxisClick,
            primary2DAxisTouch,
            menuButton,            
            secondaryButton,
            secondaryTouch,
            primaryButton,
            primaryTouch
        };

        [Tooltip("Input device role (left / right hand)")]
        public InputDeviceRole deviceRole;

        [Tooltip("Select an input feature")]
        public FeatureOptions feature;

        [Tooltip("Event when the button starts being pressed")]
        public UnityEvent OnPress;

        [Tooltip("Event when the button is released")]
        public UnityEvent OnRelease;

        // keep track of whether we are pressing the button
        bool isPressed;

        // keep devices that are detected
        List<InputDevice> devices;

        // keep value of the button press
        bool inputValue;

        // selected feature object
        InputFeatureUsage<bool> selectedFeature;

        void Awake()
        {
            // init devices list
            devices = new List<InputDevice>();

            // get label selected by the user
            string featureLabel = Enum.GetName(typeof(FeatureOptions), feature);

            // find dictionary entry
            availableFeatures.TryGetValue(featureLabel, out selectedFeature);
        }

        // Update is called once per frame
        void Update()
        {
            // get the device we want to check
            InputDevices.GetDevicesWithRole(deviceRole, devices);

            // go through our devices
            for(int i = 0; i < devices.Count; i++)
            {
                // check whether our button is being pressed
                // 1) check whether we can read the state of our button
                // 2) the button's value should be true
                if (devices[i].TryGetFeatureValue(selectedFeature, 
                    out inputValue) && inputValue) {

                    // check if we are already pressing
                    if(!isPressed)
                    {
                        // update the flag
                        isPressed = true;

                        // trigger the OnPress event
                        OnPress.Invoke();
                    }
                }
                else if(isPressed)
                {
                    // update our flag
                    isPressed = false;

                    // trigger the OnRelease event
                    OnRelease.Invoke();
                }


            }
        }
    }
}
