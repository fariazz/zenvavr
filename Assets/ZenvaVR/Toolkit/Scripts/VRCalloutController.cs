using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    [RequireComponent(typeof(Interactable))]
    public class VRCalloutController : MonoBehaviour
    {
        // object that will be shown/hidden
        public GameObject calloutObj;

        // is it showing by default?
        public bool isInitiallyVisible = false;

        // activate when hovering the reticle over?
        public bool isHoverActivated = false;

        // activate when clicking?
        public bool isClickActivated = false;

        void Awake ()
        {
            // is it initially visible?
            calloutObj.SetActive(isInitiallyVisible);
        }

        public void HandleClick ()
        {
            if(isClickActivated)
                calloutObj.SetActive(!calloutObj.activeInHierarchy);
        }

        public void HandleOut ()
        {
            if(isHoverActivated)
                calloutObj.SetActive(false);
        }

        public void HandleOver ()
        {
            if(isHoverActivated)
                calloutObj.SetActive(true);
        }
    }
}