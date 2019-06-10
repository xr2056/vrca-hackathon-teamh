using System.Collections.Generic;
using UnityEngine;

namespace ConveyorSamples
{
    public class ConveyorSC : MonoBehaviour
    {
        /// <summary>
        /// ベルトコンベアの稼働状況
        /// </summary>
        public bool IsOn = false;

        /// <summary>
        /// ベルトコンベアの設定速度
        /// </summary>
        public float TargetDriveSpeed = 3.0f;

        /// <summary>
        /// 現在のベルトコンベアの速度
        /// </summary>
        public float CurrentSpeed { get { return _currentSpeed; } }

        /// <summary>
        /// ベルトコンベアが物体を動かす方向
        /// </summary>
        public Vector3 DriveDirection = Vector3.right;

        /// <summary>
        /// コンベアが物体を押す力（加速力）
        /// </summary>
        [SerializeField] private float _forcePower = 50f;

        private float _currentSpeed = 0;
        private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

        int count = 0;

        void Start()
        {
            //方向は正規化しておく
            DriveDirection = DriveDirection.normalized;
        }

        void FixedUpdate()
        {
            _currentSpeed = IsOn ? TargetDriveSpeed : 0;

            //消滅したオブジェクトは除去する
            _rigidbodies.RemoveAll(r => r == null);

            foreach (var r in _rigidbodies)
            {
                //物体の移動速度のベルトコンベア方向の成分だけを取り出す
                var objectSpeed = Vector3.Dot(r.velocity, DriveDirection);
                var objectSpeed2 = 1 - objectSpeed / TargetDriveSpeed;

                //目標値以下なら加速する
                if (objectSpeed < Mathf.Abs(TargetDriveSpeed))
                {
                    r.AddForce(DriveDirection * _forcePower * objectSpeed2, ForceMode.Acceleration);
                    //加速される回数をカウント
                    //Debug.Log("name is " + r.name + " forceCount is " + ++count);
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
            _rigidbodies.Add(rigidBody);
        }

        void OnCollisionExit(Collision collision)
        {
            var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
            _rigidbodies.Remove(rigidBody);
        }
    }
}