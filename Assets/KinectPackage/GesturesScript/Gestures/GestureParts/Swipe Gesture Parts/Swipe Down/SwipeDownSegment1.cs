﻿// -----------------------------------------------------------------------
// <copyright file="SwipeDownSegment1.cs" company="Microsoft Limited">
//  Copyright (c) Microsoft Limited, Microsoft Consulting Services, UK. All rights reserved.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>The first part of the swipe Down gesture</summary>
//-----------------------------------------------------------------------
//namespace KinectSkeltonTracker.Gestures.GestureParts
//{
    #region using...
    using UnityEngine;
    //using Microsoft.Research.Kinect.Nui;

    #endregion

    /// <summary>
    /// The first part of the swipe Down gesture
    /// </summary>
    public class SwipeDownSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonWrapper skeletonWrapper)
        {
            // //Right hand in front of right shoulder [ 注意 Z 軸 ]
            if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight].z)
            // skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
            {
                // //right hand above right eblow height
                if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight].y)
                {
                    // //right hand above spine height
                    if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Spine].y)
                    {
                        return GesturePartResult.Suceed;
                    }

                    return GesturePartResult.Pausing;
                }

                // Debug.WriteLine("GesturePart 0 - right hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }
            else
            {
                if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].z > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft].z)
                {
                    // //left hand above left eblow height
                    if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft].y)
                    {
                        // //left hand above spine height
                        if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Spine].y)
                        {
                            return GesturePartResult.Suceed;
                        }

                        return GesturePartResult.Pausing;
                    }

                    // Debug.WriteLine("GesturePart 0 - right hand below shoulder height but above hip height - FAIL");
                    return GesturePartResult.Fail;
                }
            }

            // Debug.WriteLine("GesturePart 0 - Right hand in front of right shoulder - FAIL");
            return GesturePartResult.Fail;

            
            
        }
    }
//}