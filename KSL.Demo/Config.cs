namespace KSL.Demo
{
    using Microsoft.Kinect;

    public class KSLConfig
    {
        public ColorImageFormat colorImageFormat = ColorImageFormat.RgbResolution640x480Fps30;

        public TransformSmoothParameters transformSmoothParameters = new TransformSmoothParameters
        {
            Smoothing = 0.5f,
            Correction = 0.5f,
            Prediction = 0.5f,
            JitterRadius = 0.05f,
            MaxDeviationRadius = 0.04f
        };
    }
}
