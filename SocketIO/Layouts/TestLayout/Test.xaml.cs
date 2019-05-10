using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SocketIO.Layouts
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test : Page
    {

        Compositor _compositor = Window.Current.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;

        public Test()
        {
            this.InitializeComponent();
            if (ChoiceA.IsChecked == true)
            {

            };
        }




        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }



        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Scale up to 1.5
            CreateOrUpdateSpringAnimation(1.5f);

            (sender as UIElement).StartAnimation(_springAnimation);

        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Scale back down to 1.0
            CreateOrUpdateSpringAnimation(1.0f);

            (sender as UIElement).StartAnimation(_springAnimation);

        }








        private Boolean IsFlipped = false;

        private void MainPanel_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)

        {

            Visual visual = ElementCompositionPreview.GetElementVisual(CaptionTile);

            Compositor compositor = visual.Compositor;



            visual.Size = new Vector2((float)CaptionTile.Width / 2, (float)CaptionTile.Height / 2);



            // Rotate around the X-axis

            visual.RotationAxis = new Vector3(1, 0, 0);



            // Start the rotation animation

            LinearEasingFunction linear = compositor.CreateLinearEasingFunction();

            ScalarKeyFrameAnimation rotationAnimation = compositor.CreateScalarKeyFrameAnimation();

            if (!IsFlipped) // default

            {

                rotationAnimation.InsertKeyFrame(0, 0, linear);

                rotationAnimation.InsertKeyFrame(1, 250f, linear); // flip over

            }

            else

            {

                rotationAnimation.InsertKeyFrame(0, 250f, linear);

                rotationAnimation.InsertKeyFrame(1, 0f, linear);   // flip back



            }

            rotationAnimation.Duration = TimeSpan.FromMilliseconds(800);



            var transaction = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);

            transaction.Completed += Animation_Completed;



            // we want the CaptionTile visible as it flips back

            if (IsFlipped)

                CaptionTile.Visibility = Windows.UI.Xaml.Visibility.Visible;



            visual.StartAnimation("RotationAngleInDegrees", rotationAnimation);
            transaction.End();
        }


        private void Animation_Completed(object sender, CompositionBatchCompletedEventArgs args)
        {
            IsFlipped = !IsFlipped;
            // we want the CaptionTile invisible once flipped over

            if (IsFlipped)

                CaptionTile.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }


        private void UpdatePerspective()

        {

            Visual visual = ElementCompositionPreview.GetElementVisual(MainPanel);



            // Get the size of the area we are enabling perspective for

            Vector2 sizeList = new Vector2((float)MainPanel.ActualWidth, (float)MainPanel.ActualHeight);



            // Setup the perspective transform.

            Matrix4x4 perspective = new Matrix4x4(

                        1.0f, 0.0f, 0.0f, 0.0f,

                        0.0f, 1.0f, 0.0f, 0.0f,

                        0.0f, 0.0f, 1.0f, -1.0f / sizeList.X,

                        0.0f, 0.0f, 0.0f, 1.0f);



            // Set the parent transform to apply perspective to all children

            visual.TransformMatrix =

                               Matrix4x4.CreateTranslation(-sizeList.X / 2, -sizeList.Y / 2, 0f) *      // Translate to origin

                               perspective *                                                            // Apply perspective at origin

                               Matrix4x4.CreateTranslation(sizeList.X / 2, sizeList.Y / 2, 0f);         // Translate back to original position



        }



        private void MainPanel_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)

        {

            UpdatePerspective();

        }


    }
}
