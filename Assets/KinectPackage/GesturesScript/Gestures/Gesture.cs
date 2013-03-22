﻿// -----------------------------------------------------------------------
// <copyright file="Gesture.cs" company="Microsoft Limited">
//  Copyright (c) Microsoft Limited, Microsoft Consulting Services, UK. All rights reserved.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>A single gesture</summary>
//-----------------------------------------------------------------------
//namespace KinectSkeltonTracker.Gestures
//{
    #region using...

    using System;
    using UnityEngine;
    ///using Microsoft.Research.Kinect.Nui;

    #endregion

    /// <summary>
    /// A single gesture
    /// </summary>
    public class Gesture
    {
        public static bool isSwipeLeft = false, isSwipeRight = false, isSwipeUp = false, isSwipeDown = false;
        /// <summary>
        /// The parts that make up this gesture
        /// </summary>
        private IRelativeGestureSegment[] gestureParts;

        /// <summary>
        /// The current gesture part that we are matching against
        /// </summary>
        private int currentGesturePart = 0;

        /// <summary>
        /// the number of frames to pause for when a pause is initiated
        /// </summary>
        private int pausedFrameCount = 100;

        /// <summary>
        /// The current frame that we are on
        /// </summary>
        private int frameCount = 0;

        /// <summary>
        /// Are we paused?
        /// </summary>
        private bool paused = false;

        /// <summary>
        /// The type of gesture that this is
        /// </summary>
        private GestureType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gesture"/> class.
        /// </summary>
        /// <param name="type">The type of gesture.</param>
        /// <param name="gestureParts">The gesture parts.</param>
        public Gesture(GestureType type, IRelativeGestureSegment[] gestureParts)
        {
            this.gestureParts = gestureParts;
            this.type = type;
        }

        /// <summary>
        /// Occurs when [gesture recognised].
        /// </summary>
        ///public event EventHandler<GestureEventArgs> GestureRecognised;

        /// <summary>
        /// Updates the gesture.
        /// </summary>
        /// <param name="data">The skeleton data.</param>
        public void UpdateGesture(SkeletonWrapper skeletonWrapper)
        {
            if (this.paused)
            {
                if (this.frameCount == this.pausedFrameCount)
                {
                    this.paused = false;
                }

                this.frameCount++;
            }

            GesturePartResult result = this.gestureParts[this.currentGesturePart].CheckGesture(skeletonWrapper);
            if (result == GesturePartResult.Suceed)
            {
                if (this.currentGesturePart + 1 < this.gestureParts.Length)
                {
                    this.currentGesturePart++;
                    this.frameCount = 0;
                    this.pausedFrameCount = 10;
                    this.paused = true;
                }
                else
                {
                    //動作結束
                    //範例
                    if(this.type == GestureType.LeftSwipe)
                    {
                        isSwipeLeft = true;
                        Debug.Log("揮左成功");
                    }
                    if (this.type == GestureType.RightSwipe)
                    {
                        isSwipeRight = true;
                        Debug.Log("揮右");
                    }
                    if (this.type == GestureType.UpSwipe)
                    {
                        isSwipeUp = true;
                        Debug.Log("揮上");
                    }
                    if (this.type == GestureType.DownSwipe)
                    {
                        isSwipeDown = true;
                        Debug.Log("揮下");
                    }

                    Debug.Log("動作結束");
                    this.Reset();
                    /*
                    if (this.GestureRecognised != null)
                    {
                        this.GestureRecognised(this, new GestureEventArgs(this.type, data.TrackingID, data.UserIndex));
                        this.Reset();
                    }
                    */
                }
            }
            else if (result == GesturePartResult.Fail || this.frameCount == 50)
            {
                this.currentGesturePart = 0;
                this.frameCount = 0;
                this.pausedFrameCount = 5;
                this.paused = true;
            }
            else
            {
                this.frameCount++;
                this.pausedFrameCount = 5;
                this.paused = true;
            }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            this.currentGesturePart = 0;
            this.frameCount = 0;
            this.pausedFrameCount = 5;
            this.paused = true;
        }
    }
//}
