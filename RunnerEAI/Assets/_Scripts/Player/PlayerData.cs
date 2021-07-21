using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class PlayerData : MonoBehaviour
    {
        [field:Header("PlayerOzellikler")]
        [field:SerializeField]
        public float HorizontalSpeed { get; set; }
        
        [field: SerializeField] 
        public float VerticalSpeed { get; set; }

        [field: SerializeField]
        public float JumpPower { get; set; }
        
        
        [field: Header("Diger")]

        [SerializeField] protected float BoundX;
        
        [field: SerializeField]
        public bool IsJump { get; set; }
        public bool IsHorizontal { get; protected set; }
        
    }
}