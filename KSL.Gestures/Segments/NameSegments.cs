namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;

    public class NameSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // Right hand betwen the head and center hip and betwen left and right shoulder.
            if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.Head].Position.Y &&
                skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                // Left hand betwen the head and center hip and betwen left and right shoulder.
                if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
                {
                    // Both hands at the same height.
                    if (skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.WristRight].Position.Y)
                    {
                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }
    }

    public class NameSegment2 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // Right hand betwen the head and center hip and betwen left and right shoulder.
            if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.Head].Position.Y &&
                skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
            {
                // Left hand betwen the head and center hip and betwen left and right shoulder.
                if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.Head].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y)
                {
                    // Right hand above left left hand.
                    if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.WristRight].Position.Y)
                    {
                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }
    }
}
