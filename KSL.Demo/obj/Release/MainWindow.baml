   M S B A M L   `   `   `  ���� ^  ZMicrosoft.Samples.Kinect.WpfViewers, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers   KSL.Demo   KSL.Demo.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     mkv^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers       � Title$"  Kinect Sign Language :: beta��$
��1366��$	��768�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=����#379154.��� .+��� $��images/backgound.png��$��Center=�$
��1500��$��-88,-188,-54,188q�$��UniformToFill=�� $��Center=�$	��Top=�$	��640��$	��480��$��0, 10, 0, 0q�.+�;   5Microsoft.Samples.Kinect.WpfViewers.KinectDepthViewer  -     Name$ DepthViewer��7   1Microsoft.Samples.Kinect.WpfViewers.KinectControl   KinectSensorManager �� *KinectSensorManager+�� .+�>   8Microsoft.Samples.Kinect.WpfViewers.KinectSkeletonViewer     	ShowBones .    
ShowJoints .    
ShowCenter .    	ImageType$ Depth=� �� *KinectSensorManager+���� 	 �� ElementName$	 DepthViewer��
 �� Path$
 ActualWidth����� $	 DepthViewer��$
 ActualHeight��� $��Center=�$��Bottom=�$
��1300��$��75��$��	0,0,0,100q� �� TextAlignment$ Center=�$��48(�$
��Bold"����#FFFFFF���� *GestureBuilder+�� $��Center=�$��Bottom=�$
��1300��$��75��$��0,0,0,0q�$ Center=�$��48(�$
��Bold"����#FFFFFF���� *GestureSentence+