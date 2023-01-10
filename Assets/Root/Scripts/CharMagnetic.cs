using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    [System.Serializable]
    public struct MagnitePoint
    {
        public List<SpringJoint> JointList;
        public List<Rigidbody> RB;
        public List<ParticleSystem> Highlight;
        public Transform BlueObj, RedObj;
        public Vector3 BluePos, RedPos;
    }


    public class CharMagnetic : MonoBehaviour
    {
        [SerializeField] float _spellDistance = 20;
        [SerializeField] float _maxMagniteForce = 20;
        [SerializeField] MagnitePoint _magnitePoint;
        [SerializeField] Transform _blueHolder, _redHolder;
        [SerializeField] Material _redMat, _blueMat, _yellowMat;
        [SerializeField] ParticleSystem _hlReference;
        
        public void SetBlue(Transform trans)
        {
            _magnitePoint.BlueObj = trans;
            _magnitePoint.BluePos = trans.position;
            Highlighting(true, trans);
            CheckToJoint();
        }

        public void SetRed(Transform trans)
        {
            _magnitePoint.RedObj = trans;
            _magnitePoint.RedPos = trans.position;
            Highlighting(false, trans);
            CheckToJoint();
        }

        public void SetBlue(Vector3 trans)
        {
            _magnitePoint.BlueObj = _blueHolder;
            _magnitePoint.BluePos = trans;
            _blueHolder.position = trans;
            _blueHolder.GetChild(0).gameObject.SetActive(true);
            CheckToJoint();
        }

        public void SetRed(Vector3 trans)
        {
            _magnitePoint.RedObj = _redHolder;
            _magnitePoint.RedPos = trans;
            _redHolder.position = trans;
            _redHolder.GetChild(0).gameObject.SetActive(true);
            CheckToJoint();
        }

        private void CheckToJoint()
        {
            if(_magnitePoint.BlueObj != null && _magnitePoint.RedObj != null)
            {
                if (Vector3.Distance(_magnitePoint.RedPos, _magnitePoint.BluePos) < _spellDistance) CreateJoint();
                else EreaseSpell();
            }
        }

        private void CreateJoint()
        {
            SpringJoint sp = _magnitePoint.BlueObj.gameObject.AddComponent<SpringJoint>();
            sp.autoConfigureConnectedAnchor = false;
            sp.anchor = Vector3.zero;
            sp.connectedAnchor = Vector3.zero;
            sp.enableCollision = true;
            sp.enablePreprocessing = false;

            sp.connectedBody = _magnitePoint.RedObj.GetComponent<Rigidbody>();

            EreaseSpell();
            _magnitePoint.JointList.Add(sp);

            Rigidbody rb = sp.GetComponent<Rigidbody>();
            _magnitePoint.RB.Add(rb);
            AddRG(sp.connectedBody);
        }

        private void AddRG(Rigidbody RB)
        {
            if(_magnitePoint.RB == null) { return; }

            for(int i = 0; i< _magnitePoint.RB.Count; i++)
            {
                if (RB == _magnitePoint.RB[i]) break;
                if (i == _magnitePoint.RB.Count - 1)
                {
                    _magnitePoint.RB.Add(RB);
                    break;
                }
            }           
        }

        private void Highlighting(bool isBlue, Transform trans)
        {
            ParticleSystem ps = Instantiate(_hlReference, trans, false);

            if (isBlue) ps.GetComponent<Renderer>().material = _blueMat;
            else ps.GetComponent<Renderer>().material = _redMat;

            _magnitePoint.Highlight.Add(ps);
        }

        private void EreaseSpell()
        {
            _magnitePoint.BlueObj = null;
            _magnitePoint.RedObj = null;

            for (int i = 0; i < _magnitePoint.Highlight.Count; i++)
                _magnitePoint.Highlight[i].GetComponent<Renderer>().material = _yellowMat;
        }

        private void DestroyAllJoyints()
        {
            for (int i = 0; i < _magnitePoint.JointList.Count; i++)            
                Destroy(_magnitePoint.JointList[i]);

            for (int i = 0; i < _magnitePoint.Highlight.Count; i++)
                Destroy(_magnitePoint.Highlight[i]);

            for (int i = 0; i < _magnitePoint.RB.Count; i++)
            {
                _magnitePoint.RB[i].angularDrag = 0.5f;
                _magnitePoint.RB[i].drag = 0;
                _magnitePoint.RB[i].WakeUp();
            }

            _magnitePoint.JointList.Clear();
            _magnitePoint.Highlight.Clear();
            _magnitePoint.RB.Clear();
            EreaseSpell();
            DisableHolders();        
        }

        private void DisableHolders()
        {
            _blueHolder.GetChild(0).gameObject.SetActive(false);
            _redHolder.GetChild(0).gameObject.SetActive(false);
        }

        public void ChangeSpringPower(float fNum)
        {
            if (_magnitePoint.JointList.Count > 0)
            {
                for (int i = 0; i < _magnitePoint.JointList.Count; i++)
                {
                    _magnitePoint.JointList[i].spring += fNum;
                    _magnitePoint.JointList[i].damper += fNum;
                    _magnitePoint.JointList[i].spring = Mathf.Clamp(_magnitePoint.JointList[i].damper, 0, _maxMagniteForce);
                    _magnitePoint.JointList[i].damper = Mathf.Clamp(_magnitePoint.JointList[i].damper, 0, _maxMagniteForce);
                }

                for (int i = 0; i < _magnitePoint.RB.Count; i++)
                {
                    _magnitePoint.RB[i].WakeUp();

                    _magnitePoint.RB[i].angularDrag += fNum;
                    _magnitePoint.RB[i].drag += fNum;

                    _magnitePoint.RB[i].angularDrag = Mathf.Clamp(_magnitePoint.RB[i].angularDrag, 0, _maxMagniteForce); ;
                    _magnitePoint.RB[i].drag = Mathf.Clamp(_magnitePoint.RB[i].drag, 0, _maxMagniteForce);
                }
            }
        }
    }
}