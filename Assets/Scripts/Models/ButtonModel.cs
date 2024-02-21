using System;
using Enums;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ButtonModel : BaseModel
    {
        public string text;
        public bool hasAnimation;
        public float[] Color { get; set; } 
    }
}
