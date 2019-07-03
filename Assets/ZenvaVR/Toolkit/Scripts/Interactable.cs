using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zenva.VR
{
    public class Interactable : MonoBehaviour
    {
        // pointer hits the object
        public UnityEvent OnOver;

        // pointer leaves the object
        public UnityEvent OnOut;

        // a button is pressed while selecting
        public UnityEvent OnButtonDown;

        // flag to keep track of our selection
        bool isOver = false;

        public void Over()
        {
            // check we were not selecting it
            if (!isOver)
            {
                // update flag
                isOver = true;

                // trigger event
                OnOver.Invoke();
            }
        }

        public void Out()
        {
            // check that we were selecting it
            if (isOver)
            {
                // update flag
                isOver = false;

                // trigger event
                OnOut.Invoke();
            }
        }

        public void ButtonDown()
        {
            OnButtonDown.Invoke();
        }
    }
}