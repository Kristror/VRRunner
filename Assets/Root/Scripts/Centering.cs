using System.Collections;
using UnityEngine;

namespace Runner
{
    public class Centering : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        [SerializeField] private CapsuleCollider _collider;

        private Vector3 vec;

        private void OnValidate()
        {
            _collider = GetComponent<CapsuleCollider>();
        }

        void Start()
        {
            FindTeleportPivotAndTarget();
            vec.y = _collider.center.y;
        }

        void Update()
        {
            vec.x = _pivot.localPosition.x;
            vec.z = _pivot.localPosition.z;
        }

        private void FindTeleportPivotAndTarget() 
        {
            foreach(var cam in Camera.allCameras)
            {
                if(!cam.enabled) { continue; }
                if(cam.stereoTargetEye != StereoTargetEyeMask.Both) { continue; }
                _pivot = cam.transform;
            }
        }
    }
}