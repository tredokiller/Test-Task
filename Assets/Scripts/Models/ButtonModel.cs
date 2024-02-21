using System;

namespace Models
{
    [Serializable]
    public class ButtonModel : BaseModel
    {
        public string text;
        public bool hasAnimation;
        public float[] color { get; set; } 
    }
}
