using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenva.VR
{
    public class ColorChanger : MonoBehaviour
    {
        public void ChangeToRed()
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        public void ChangeToYellow()
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        public void ChangeToGreen()
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}