using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    public class FreeTeleportationZone : MonoBehaviour
    {
        FreeTeleportController playerCtrl;

        void Start ()
        {
            playerCtrl = FindObjectOfType<FreeTeleportController>();
        }

        // called when our hand pointer enters the zone
        public void HandleOver ()
        {
            playerCtrl.ShowTarget();
        }

        // called when our hand pointer exits the zone
        public void HandleOut ()
        {
            playerCtrl.HideTarget();
        }

        // called when we click on the free teleportation zone
        public void HandleButtonDown ()
        {
            playerCtrl.Teleport();
        }
    }
}