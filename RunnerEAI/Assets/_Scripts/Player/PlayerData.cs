using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class PlayerData : MonoBehaviour
    {
        [field: SerializeField]
        public float HorizontalSpeed { get; protected set; }
        
        [field: SerializeField] 
        public float VerticalSpeed { get; protected set; }

        [field: SerializeField]
        public float JumpPower { get; protected set; }

        [field: SerializeField]
        public bool IsJump { get; set; }

        [SerializeField] protected float BoundX;
        public bool IsHorizontal { get; protected set; }

    }
}