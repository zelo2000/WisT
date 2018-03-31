﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

#if (NETFX_CORE || UNITY_EDITOR || UNITY_IOS || UNITY_ANDROID || UNITY_STANDALONE)
using System;
using System.Runtime.InteropServices;

namespace System.Drawing
{
#if !(NETFX_CORE || NETSTANDARD1_4)
   [Serializable]
#endif
   [StructLayout(LayoutKind.Sequential)]
   public struct Size : IEquatable<Size>
   {
      public int Width;
      public int Height;

      public Size(int width, int height)
      {
         Width = width;
         Height = height;
      }

      public static Size Empty
      {
         get
         {
            return new Size(0, 0);
         }
      }

      public bool Equals(Size other)
      {
         return (Width == other.Width) && (Height == other.Height); 
      }

      public static bool operator ==(Size s1, Size s2)
      {
         return s1.Equals(s2);
      }

      public static bool operator !=(Size s1, Size s2)
      {
         return !s1.Equals(s2);
      }

      public override bool Equals(object obj)
      {
         Size? s2 = obj as Size?;
         if (!s2.HasValue)
            return false;
         return Equals(s2.Value);
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }
   }
}

#endif