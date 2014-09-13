namespace KSL.Gestures.Core
{
    using Microsoft.Kinect;
    using System;

    class Gesture
    {
        private IGesturesSegment[] gestureParts; // the parts that make up the gesture.

        private int currentGesturePart = 0; // the current gesture part that we are matching against

        private int pausedFrameCount = 10; // the number of frames to pause for when a pause is initiated

        private int frameCount = 0; // the current frame that we are on

        private bool paused = false; // are we paused?

        private string name; // the name of the gesture

        public event EventHandler<GesturesEventArgs> GestureRecognized; // occurs when gesture recognized

        public Gesture(string name, IGesturesSegment[] gestureParts)
        {
            this.name = name;
            this.gestureParts = gestureParts;
        }

        public void UpdateGesture(Skeleton data)
        {
            if (this.paused)
            {
                if (this.frameCount == this.pausedFrameCount)
                {
                    this.paused = false;
                }

                this.frameCount += 1;
            }

            GesturePartResult result = this.gestureParts[this.currentGesturePart].CheckGesture(data);

            if (result == GesturePartResult.Succeed)
            {
                if (this.currentGesturePart + 1 < this.gestureParts.Length)
                {
                    this.currentGesturePart += 1;
                    this.frameCount = 0;
                    this.pausedFrameCount = 10;
                    this.paused = true;
                }
                else
                {
                    if (this.GestureRecognized != null)
                    {
                        this.GestureRecognized(this, new GesturesEventArgs(this.name, data.TrackingId));
                        this.Reset();
                    }
                }
            }
            else if (result == GesturePartResult.Fail || this.frameCount == 50)
            {
                this.Reset();
            }
            else
            {
                this.frameCount += 1;
                this.pausedFrameCount = 5;
                this.paused = true;
            }
        }

        public void Reset()
        {
            this.currentGesturePart = 0;
            this.frameCount = 0;
            this.pausedFrameCount = 5;
            this.paused = true;
        }

    }
}
