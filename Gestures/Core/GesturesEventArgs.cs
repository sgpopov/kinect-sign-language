namespace KSL.Gestures.Core
{
    using System;

    public class GesturesEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the type of the gesture.
        /// </summary>
        public string GestureName { get; set; }

        /// <summary>
        /// Gets or sets the tracking ID.
        /// </summary>
        public int TrackignId { get; set; }

        public GesturesEventArgs(string name, int trackingId)
        {
            this.TrackignId = trackingId;
            this.GestureName = name;
        }
    }
}
