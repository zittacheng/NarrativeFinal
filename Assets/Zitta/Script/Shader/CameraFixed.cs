using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STR
{
    [ExecuteInEditMode]
    public class CameraFixed : MonoBehaviour {
        public Material Mat;

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(source, destination, Mat);
        }
    }
}