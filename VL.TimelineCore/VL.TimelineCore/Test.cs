

using System;
using System.Windows.Media.Animation;
using NUnit.Framework;
using DoubleAnimationUsingKeyFrames = VL.TimelineCore.DoubleAnimationUsingKeyFrames;

namespace VL.TimelineCoreTest
{
    public class Tests
    {
        
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Create a DoubleAnimationUsingKeyFrames to
            // animate the TranslateTransform.
            DoubleAnimationUsingKeyFrames translationAnimation
                = new DoubleAnimationUsingKeyFrames();
            translationAnimation.Duration = TimeSpan.FromSeconds(6);

            translationAnimation.KeyFrames.Add(
                new LinearDoubleKeyFrame(
                    0, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))) // KeyTime
            );
            
            // Animate from the starting position to 500
            // over the first second using linear
            // interpolation.
            translationAnimation.KeyFrames.Add(
                new LinearDoubleKeyFrame(
                    500, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))) // KeyTime
            );

            // Animate from 500 (the value of the previous key frame)
            // to 400 at 4 seconds using discrete interpolation.
            // Because the interpolation is discrete, the rectangle will appear
            // to "jump" from 500 to 400.
            translationAnimation.KeyFrames.Add(
                new DiscreteDoubleKeyFrame(
                    400, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4))) // KeyTime
            );

            // Animate from 400 (the value of the previous key frame) to 0
            // over two seconds, starting at 4 seconds (the key time of the
            // last key frame) and ending at 6 seconds.
            translationAnimation.KeyFrames.Add(
                new SplineDoubleKeyFrame(
                    0, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), // KeyTime
                    new KeySpline(0.6,0.0,0.9,0.0) // KeySpline
                )
            );

            // Set the animation to repeat forever.
            translationAnimation.RepeatBehavior = RepeatBehavior.Forever;

            Assert.AreEqual(250,translationAnimation.GetCurrentValueCore(0, 1, TimeSpan.FromSeconds(1.5d)),0.1);
        }
    }
}