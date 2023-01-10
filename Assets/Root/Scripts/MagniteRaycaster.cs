using HTC.UnityPlugin.Pointer3D;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runner
{
    public class MagniteRaycaster : MonoBehaviour
    {
        public enum TypeOfMagnite
        {
            Blue,
            Red
        }

        [SerializeField] private TypeOfMagnite _colorOfMagnite;
        [SerializeField] private CharMagnetic _refToChar;

        private RaycastResult _curObj;
        private Pointer3DRaycaster _raycaster;

        private void OnValidate()
        {
            _raycaster = GetComponent<Pointer3DRaycaster>();
        }

        private void LateUpdate()
        {
            Raycasting();
        }

        private void Raycasting()
        {
            _curObj = _raycaster.FirstRaycastResult();
        }

        public void StartMagnite()
        {
            if (_curObj.isValid)
            {
                Rigidbody RB = _curObj.gameObject.GetComponent<Rigidbody>();

                switch ((int)_colorOfMagnite)
                {
                    case 0:
                        if (RB != null) _refToChar.SetBlue(_curObj.gameObject.transform);
                        else _refToChar.SetBlue(_curObj.worldPosition);
                        break;
                    case 1:
                        if (RB != null) _refToChar.SetRed(_curObj.gameObject.transform);
                        else _refToChar.SetRed(_curObj.worldPosition);
                        break;
                }
            }
            else return;
        }
    }
}