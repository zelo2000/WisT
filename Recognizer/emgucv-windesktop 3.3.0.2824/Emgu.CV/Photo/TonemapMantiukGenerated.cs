//----------------------------------------------------------------------------
//  This file is automatically generated, do not modify.      
//----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Emgu.CV
{
   public static partial class CvInvoke
   {

     [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)] 
     internal static extern float cveTonemapMantiukGetSaturation(IntPtr obj);
     [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
     internal static extern void cveTonemapMantiukSetSaturation(
        IntPtr obj,  
        float val);
     
     [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)] 
     internal static extern float cveTonemapMantiukGetScale(IntPtr obj);
     [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
     internal static extern void cveTonemapMantiukSetScale(
        IntPtr obj,  
        float val);
     
   }

   public partial class TonemapMantiuk
   {

     /// <summary>
     /// Saturation enhancement value.
     /// </summary>
     public float Saturation
     {
        get { return CvInvoke.cveTonemapMantiukGetSaturation(_ptr); } 
        set { CvInvoke.cveTonemapMantiukSetSaturation(_ptr, value); }
     }
     
     /// <summary>
     /// Contrast scale factor. HVS response is multiplied by this parameter, thus compressing dynamic range. Values from 0.6 to 0.9 produce best results.
     /// </summary>
     public float Scale
     {
        get { return CvInvoke.cveTonemapMantiukGetScale(_ptr); } 
        set { CvInvoke.cveTonemapMantiukSetScale(_ptr, value); }
     }
     
   }
}