using System;

namespace DefaultNamespace
{
    [Flags]
    public enum Moving
    {
        Vertical = 2, 
        Horizontal = 4,
        Diagonal = 6,
        LikeL = 8,
    }
}