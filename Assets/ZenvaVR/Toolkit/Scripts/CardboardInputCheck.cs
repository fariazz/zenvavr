using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zenva.VR
{
    public class CardboardInputCheck : MonoBehaviour
    {
        public UnityEvent OnClick;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                OnClick.Invoke();
            }
        }
    }
}