using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    [RequireComponent(typeof(LineRenderer))]
    public class FreeTeleportController : MonoBehaviour
    {
        [Tooltip("Player rig we want to move")]
        public Transform playerRig;

        [Tooltip("Hand which will control the free teleportation")]
        public Transform pointerHand;

        // vr pointer component attached to our pointer hand
        VrPointer vrPointer;

        [Tooltip("Number of points in the arc")]
        public int numArcPoints = 6;

        // keep track of whether we are showing or not
        bool isShowing;

        // line renderer
        LineRenderer lineRend;

        // target marker showing where we teleport to
        GameObject targetObj;

        // points of the arc
        Vector3[] arcPoints;

        void Start ()
        {
            lineRend = GetComponent<LineRenderer>();
            targetObj = transform.GetChild(0).gameObject;
            vrPointer = pointerHand.GetComponent<VrPointer>();

            if(lineRend == null)
            {
                Debug.LogError("Make sure the target has a Line Renderer");
            }

            // set number of points
            lineRend.positionCount = numArcPoints;

            // points vector
            arcPoints = new Vector3[numArcPoints];

            HideTarget();
        }

        // hide the target
        public void HideTarget ()
        {
            targetObj.SetActive(false);
            lineRend.enabled = false;

            // update our flag
            isShowing = false;
        }

        // show target
        public void ShowTarget ()
        {
            Vector3 position = vrPointer.EndPosition;

            targetObj.SetActive(true);
            lineRend.enabled = true;

            // set the teleport target to the position we are pointing at
            targetObj.transform.position = position;

            //update flag
            isShowing = true;

            // show ray           
            DrawRay();
        }

        void Update ()
        {
            // are we showing the ray?
            if(isShowing)
            {
                // set the teleport target to the position we are pointing at
                targetObj.transform.position = vrPointer.EndPosition;

                DrawRay();
            }
        }

        //teleportation
        public void Teleport ()
        {
            if(isShowing)
            {
                // player position will be equal to the target position
                playerRig.position = targetObj.transform.position;
                //HideTarget();
            }
        }

        // draw ray
        void DrawRay ()
        {
            // starting position of the arc
            Vector3 startPoint = pointerHand.position;

            // ending position
            Vector3 endPoint = targetObj.transform.position;

            // arc effect
            float arcY;

            // create all the points until the end
            for(int i = 0; i < numArcPoints; i++)
            {
                // arc effect
                arcY = Mathf.Sin((float)i / numArcPoints * Mathf.PI) / 2;

                // create point
                arcPoints[i] = Vector3.Lerp(startPoint, endPoint, (float)i / numArcPoints);
                arcPoints[i].y += arcY;
            }

            // assign points to the line renderer
            lineRend.SetPositions(arcPoints);
        }

        // return whether we are selecting or not
        public bool IsSelecting ()
        {
            return isShowing;
        }
    }
}