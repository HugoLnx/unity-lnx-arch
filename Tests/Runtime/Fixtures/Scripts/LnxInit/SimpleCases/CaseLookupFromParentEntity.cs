using System.Collections.Generic;
using LnxArch.TestTools;
using UnityEngine;

namespace LnxArch.TestFixtures
{
    public class CaseLookupFromParentEntity : MonoBehaviour
    {
        [SerializeField] private bool _log;
        public Collider Collider { get; private set; }
        public List<Collider> Colliders { get; private set; }

        [LnxInit]
        public void PrepareOne(
            [FromParentEntity]
            Collider collider
        )
        {
            Collider = collider;
            if (_log) Debug.Log($"[Prepared:{this.GetType().Name}-{this.name}] collider:{Collider}");
            CallsRegister.FindAndRecordFor(this, nameof(PrepareOne));
        }

        [LnxInit]
        public void PrepareMany(
            [FromParentEntity]
            List<Collider> colliders
        )
        {
            Colliders = colliders;
            if (_log) Debug.Log($"[Prepared:{this.GetType().Name}-{this.name}] colliders:{Colliders.Count}");
            CallsRegister.FindAndRecordFor(this, nameof(PrepareMany));
        }
    }
}