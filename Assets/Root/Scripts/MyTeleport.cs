using HTC.UnityPlugin.Vive;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runner
{
    public class MyTeleport : Teleportable
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _cooldown;

        public override IEnumerator StartTeleport(RaycastResult hitResult, Vector3 position, Quaternion rotation, float delay)
        {
            while (true)
            {           
                target.position = Vector3.MoveTowards(target.position, position, _speed * Time.deltaTime);

                Vector3 v = position;
                v.y = target.position.y;

                if(Vector3.Distance(target.position, v) < 0.1f)
                {
                    yield return new WaitForSeconds(_cooldown);
                    teleportCoroutine = null;
                    yield break;
                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}