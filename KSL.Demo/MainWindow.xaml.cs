namespace KSL.Demo
{
    using KSL.Gestures.Classifier;
    using KSL.Gestures.Core;
    using KSL.Gestures.Logger;
    using KSL.Gestures.Segments;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Samples.Kinect.WpfViewers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows;
    using System.Windows.Data;

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region "Declaration"

        private KSLConfig config = new KSLConfig();
        private readonly KinectSensorChooser sensorChooser = new KinectSensorChooser();
        private Skeleton[] skeletons = new Skeleton[0];
        private GesturesController gestureController;

        public event PropertyChangedEventHandler PropertyChanged;
        
        Classifier classifier = Classifier.getInstance;
        private Logger logger = Logger.getInstance;

        private string gestureSentence;
        private string gestureBuilder;

        #endregion

        #region "Constructor"

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            classifier.init();
            InitializeKinect();
        }

        #endregion

        #region "Initialize Kinect"

        private void InitializeKinect()
        {
            // initialize the Kinect sensor manager
            KinectSensorManager = new KinectSensorManager();
            KinectSensorManager.KinectSensorChanged += this.KinectSensorChanged;

            // locate an available sensor
            sensorChooser.Start();

            // bind chooser's sensor value to the local sensor manager
            var kinectSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.KinectSensorManager, KinectSensorManager.KinectSensorProperty, kinectSensorBinding);
        }

        private void KinectSensorChanged(object sender, KinectSensorManagerEventArgs<KinectSensor> args)
        {
            if (null != args.OldValue)
                UninitializeKinectServices(args.OldValue);

            if (null != args.NewValue)
                InitializeKinectServices(KinectSensorManager, args.NewValue);
        }

        private void InitializeKinectServices(KinectSensorManager kinectSensorManager, KinectSensor sensor)
        {
            kinectSensorManager.ColorFormat = config.colorImageFormat;
            kinectSensorManager.ColorStreamEnabled = true;

            kinectSensorManager.DepthStreamEnabled = true;

            kinectSensorManager.TransformSmoothParameters = config.transformSmoothParameters;

            sensor.SkeletonFrameReady += OnSkeletonFrameReady;
            kinectSensorManager.SkeletonStreamEnabled = true;

            kinectSensorManager.KinectSensorEnabled = true;

            if (!kinectSensorManager.KinectSensorAppConflict)
            {
                gestureController = new GesturesController();
                gestureController.GestureRecognized += OnGestureRecognized;

                RegisterGestures();
            }
        }

        private void UninitializeKinectServices(KinectSensor sensor)
        {
            sensor.SkeletonFrameReady -= OnSkeletonFrameReady;
            gestureController.GestureRecognized -= OnGestureRecognized;
        }

        private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame == null)
                    return;

                // resize the skeletons array if needed
                if (skeletons.Length != frame.SkeletonArrayLength)
                    skeletons = new Skeleton[frame.SkeletonArrayLength];

                // get the skeleton data
                frame.CopySkeletonDataTo(skeletons);

                foreach (var skeleton in skeletons)
                {
                    // skip the skeleton if it is not being tracked
                    if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
                        continue;

                    // update the gesture controller
                    gestureController.UpdateAllGestures(skeleton);
                }
            }
        }

        public static readonly DependencyProperty KinectSensorManagerProperty = DependencyProperty.Register
        (
            "KinectSensorManager",
            typeof(KinectSensorManager),
            typeof(MainWindow),
            new PropertyMetadata(null)
        );

        public KinectSensorManager KinectSensorManager
        {
            get { return GetValue(KinectSensorManagerProperty) as KinectSensorManager; }
            set { SetValue(KinectSensorManagerProperty, value); }
        }

        #endregion

        #region "Gestures - Register, Recognize"

        private void RegisterGestures()
        {
            // Word: Hello
            IGesturesSegment[] helloSegments = new IGesturesSegment[2];
            HelloSegment1 helloSegment1 = new HelloSegment1();
            HelloSegment2 helloSegment2 = new HelloSegment2();
            helloSegments[0] = helloSegment1;
            helloSegments[1] = helloSegment2;
            gestureController.AddGesture("Hello", helloSegments);

            // Word: You / Your / You're
            IGesturesSegment[] youSegments = new IGesturesSegment[2];
            YouSegment1 youSegment1 = new YouSegment1();
            YouSegment2 youSegment2 = new YouSegment2();
            youSegments[0] = youSegment1;
            youSegments[1] = youSegment2;
            gestureController.AddGesture("You", youSegments);

            // Word: Name
            IGesturesSegment[] nameSegments = new IGesturesSegment[4];
            NameSegment1 nameSegment1 = new NameSegment1();
            NameSegment2 nameSegment2 = new NameSegment2();
            nameSegments[0] = nameSegment1;
            nameSegments[1] = nameSegment2;
            nameSegments[2] = nameSegment1;
            nameSegments[3] = nameSegment2;
            gestureController.AddGesture("Name", nameSegments);

            // Word: City
            IGesturesSegment[] citySegments = new IGesturesSegment[3];
            CitySegment1 citySegment1 = new CitySegment1();
            CitySegment2 citySegment2 = new CitySegment2();
            citySegments[0] = citySegment1;
            citySegments[1] = citySegment2;
            citySegments[2] = citySegment1;
            gestureController.AddGesture("City", citySegments);

            // Word: Live
            IGesturesSegment[] liveSegments = new IGesturesSegment[3];
            LiveSegment1 liveSegment1 = new LiveSegment1();
            LiveSegment2 liveSegment2 = new LiveSegment2();
            LiveSegment3 liveSegment3 = new LiveSegment3();
            liveSegments[0] = liveSegment1;
            liveSegments[1] = liveSegment2;
            liveSegments[2] = liveSegment3;
            gestureController.AddGesture("Live", liveSegments);

            // Word: Drive
            IGesturesSegment[] driveSegments = new IGesturesSegment[4];
            DriveSegment1 driveSegment1 = new DriveSegment1();
            DriveSegment2 driveSegment2 = new DriveSegment2();
            driveSegments[0] = driveSegment1;
            driveSegments[1] = driveSegment2;
            driveSegments[2] = driveSegment1;
            driveSegments[3] = driveSegment2;
            gestureController.AddGesture("Drive", driveSegments);

            // Word: Age / Old
            IGesturesSegment[] ageSegments = new IGesturesSegment[2];
            AgeSegment1 ageSegment1 = new AgeSegment1();
            AgeSegment2 ageSegment2 = new AgeSegment2();
            ageSegments[0] = ageSegment1;
            ageSegments[1] = ageSegment2;
            gestureController.AddGesture("Age", ageSegments);
        }

        private void OnGestureRecognized(object sender, GesturesEventArgs e)
        {
            switch (e.GestureName)
            {
                case "Hello":
                    display(WordsEnum.Hello);
                    break;
                case "You":
                    display(WordsEnum.You);
                    break;
                case "Name":
                    display(WordsEnum.Name);
                    break;
                case "City":
                    display(WordsEnum.City);
                    break;
                case "Live":
                    display(WordsEnum.Live);
                    break;
                case "Drive":
                    display(WordsEnum.Drive);
                    break;
                case "Age":
                    display(WordsEnum.Age);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region "Display text"

        private void display(WordsEnum word)
        {
            classifier.addCode((int) word);
            classifier.findSentence();
            string sentence = classifier.getSentence();
            List<int> sentenceBuilder = classifier.getSentenceBuilder();

            logger.logMessage(String.Format("Main Window = [ {0} ]", String.Join(", ", sentenceBuilder)), errorFlag.SentenceBuilderState);

            if (sentenceBuilder.Count > 1 && !String.IsNullOrEmpty(sentence))
            {
                StringBuilder sb = new StringBuilder();
                GestureBuilder = String.Empty;
                foreach (int wordCode in sentenceBuilder)
                {
                    sb.Append(Enum.GetName(typeof(WordsEnum), wordCode));
                    sb.Append(" ● ");
                }
                sb.Length = sb.Length - 3;
                GestureBuilder = sb.ToString();
                GestureSentence = sentence;
            }
            else
            {
                GestureSentence = String.Empty;
                GestureBuilder = Enum.GetName(typeof(WordsEnum), word);
            }
        }

        public String GestureSentence
        {
            get { return gestureSentence; }

            private set
            {
                if (gestureSentence == value)
                    return;

                gestureSentence = value;

                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GestureSentence"));
            }
        }

        public String GestureBuilder
        {
            get { return gestureBuilder; }

            private set
            {
                if (gestureBuilder == value)
                    return;

                gestureBuilder = value;

                if(this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GestureBuilder"));
            }
        }

        #endregion
    }
}
