namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;

    public class CitySegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // Both hands betwen left and right shoulders and above spine.
            if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.Spine].Position.Y &&
                skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.Spine].Position.Y)
            {
                // Left hand right of left wrist and left of right wrist.
                // Right hand right of left wrist and left of right wrist.
                if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.WristLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.WristRight].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.WristRight].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.WristLeft].Position.X)
                {
                    if (skeleton.Joints[JointType.WristRight].Position.Z < skeleton.Joints[JointType.WristLeft].Position.Z)
                    {
                        float pointA1 = Scale(640, 1, skeleton.Joints[JointType.WristRight].Position.X);
                        float pointA2 = Scale(480, 1, skeleton.Joints[JointType.WristRight].Position.Y);
                        float pointB1 = Scale(640, 1, skeleton.Joints[JointType.WristRight].Position.X);
                        float pointB2 = Scale(480, 1, skeleton.Joints[JointType.WristRight].Position.Y);

                        float test1 = skeleton.Joints[JointType.Spine].Position.Z / skeleton.Joints[JointType.WristRight].Position.Z;
                        float test = skeleton.Joints[JointType.WristRight].Position.Z / skeleton.Joints[JointType.WristLeft].Position.Z;

                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }
                return GesturePartResult.Fail;
            }
            return GesturePartResult.Fail;
        }

        private static float Scale(int maxPixel, float maxSkeleton, float position)
        {
            float value = ((((maxPixel / maxSkeleton) / 2) * position) + (maxPixel / 2));
            if (value > maxPixel)
                return maxPixel;
            if (value < 0)
                return 0;
            return value;
        }
    }


    public class CitySegment2 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            // Both hands betwen left and right shoulders.
            if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.Spine].Position.Y &&
                skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.Spine].Position.Y)
            {
                // Left hand right of left wrist and left of right wrist.
                // Right hand right of left wrist and left of right wrist.
                if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.WristLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.WristRight].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.WristRight].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.WristLeft].Position.X)
                {
                    if (skeleton.Joints[JointType.WristRight].Position.Z < skeleton.Joints[JointType.WristLeft].Position.Z)
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
