﻿// -----------------------------------------------------------------------
// <copyright file="SwipeRightSegment3.cs" company="Microsoft Limited">
//  Copyright (c) Microsoft Limited, Microsoft Consulting Services, UK. All rights reserved.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>The third part of the swipe right gesture</summary>
//-----------------------------------------------------------------------
//namespace KinectSkeltonTracker.Gestures.GestureParts
//{
    #region using...

    using UnityEngine;
    //using Microsoft.Research.Kinect.Nui;

    #endregion

    /// <summary>
    /// The third part of the swipe right gesture
    /// </summary>
    public class SwipeRightSegment3 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        /// 
        public GesturePartResult CheckGesture(SkeletonWrapper skeletonWrapper)
        {
            // //left hand in front of left Shoulder
            if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].z > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft].z)
            //skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
            {
                // //left hand below shoulder height but above hip height
                if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y &&
                    skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
                {
                    // //left hand left of right Shoulder
                    if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].x > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].x)
                    {
                        return GesturePartResult.Suceed;
                    }
                    return GesturePartResult.Pausing;
                }
                return GesturePartResult.Fail;
            }
            else
            {
                if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight].z)
                {
                    if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y &&
                        skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
                    {
                        if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].x)
                        {
                            return GesturePartResult.Suceed;
                        }
                        return GesturePartResult.Pausing;
                    }
                    return GesturePartResult.Fail;
                }
            }
            return GesturePartResult.Fail;
        }
    }
//}