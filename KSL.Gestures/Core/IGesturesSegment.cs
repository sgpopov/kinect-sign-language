namespace KSL.Gestures.Core
{
    using Microsoft.Kinect;
    using System;

    public interface IGesturesSegment
    {
        GesturePartResult CheckGesture(Skeleton skeleton);
    }
}
