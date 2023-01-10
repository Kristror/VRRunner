using HTC.UnityPlugin.Vive;
using UnityEngine;
using Valve.VR;

namespace Runner
{
    public class TrackPadScroller : MonoBehaviour
    {
        [SerializeField] private float _speed = 10, _deadZone = 0.1f;

        private SteamVR_RenderModel vive;
        private CharMagnetic _magnite;

        private void Start()
        {
            _magnite = GetComponent<CharMagnetic>();
        }

        private void Update()
        {
            if (vive == null) vive = GetComponentInChildren<SteamVR_RenderModel>();

            float dp = ViveInput.GetPadTouchDelta(HandRole.RightHand).y;

            if(Mathf.Abs(dp) >_deadZone)
            {
                _magnite.ChangeSpringPower(dp * _speed);
                vive.controllerModeState.bScrollWheelVisible = true;
            }
            if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.PadTouch))
                vive.controllerModeState.bScrollWheelVisible = false; 
            
            dp = ViveInput.GetPadTouchDelta(HandRole.LeftHand).y;

            if (Mathf.Abs(dp) > _deadZone)
            {
                _magnite.ChangeSpringPower(dp * _speed);
                vive.controllerModeState.bScrollWheelVisible = true;
            }
            if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.PadTouch))
                vive.controllerModeState.bScrollWheelVisible = false;
        }
    }
}