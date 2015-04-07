namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

    public class BicycleSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.Spine].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.Spine].Position.X)
            {
                if (skeleton.Joints[JointType.ElbowLeft].Position.Z > skeleton.Joints[JointType.HandRight].Position.Z)
                {
                    return GesturePartResult.Succeed;
                }

                return GesturePartResult.Pausing;
            }

            return GesturePartResult.Fail;
        }
    }

    public class BicycleSegment2 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.Spine].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.Spine].Position.X)
            {
                if (skeleton.Joints[JointType.ElbowRight].Position.Z > skeleton.Joints[JointType.HandLeft].Position.Z)
                {
                    return GesturePartResult.Succeed;
                }

                return GesturePartResult.Pausing;
            }

            return GesturePartResult.Fail;
        }
    }
}
