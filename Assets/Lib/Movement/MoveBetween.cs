using System;
using UnityEngine;

namespace Lib.Movement
{
    public class MoveBetween : MonoBehaviour
    {
        [SerializeField] protected Transform obj;
        [SerializeField] protected Transform from;
        [SerializeField] protected Transform to;
        [SerializeField] protected float speed;

        protected Transform _target;

        protected virtual void Awake()
        {
            _target = to;
        }

        // Update is called once per frame
        protected virtual void FixedUpdate()
        {
            if (Vector3.Distance(obj.position, _target.position) < 0.01f)
            {
                _target = _target == from ? to : from;
            }

            obj.position = Vector3.MoveTowards(obj.position, _target.position, speed * Time.deltaTime);
        }
    }
}
