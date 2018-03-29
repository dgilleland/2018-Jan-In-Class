using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;

namespace WebApp.Utilities
{
    public static class ImageUploadHelpers
    {
        #region Private Fields/Properties - Image Formats
        private static SortedDictionary<Guid, string> _ImageFormats = null;

        private static SortedDictionary<Guid, string> ImageFormats
        {
            get
            {
                if (_ImageFormats == null)
                {
                    _ImageFormats = new SortedDictionary<Guid, string>();
                    // Set up the dictionary 
                    _ImageFormats.Add(ImageFormat.Bmp.Guid, "image/bmp");
                    _ImageFormats.Add(ImageFormat.Emf.Guid, "image/emf");
                    _ImageFormats.Add(ImageFormat.Exif.Guid, "image/exif");
                    _ImageFormats.Add(ImageFormat.Gif.Guid, "image/gif");
                    _ImageFormats.Add(ImageFormat.Jpeg.Guid, "image/jpeg");
                    _ImageFormats.Add(ImageFormat.Png.Guid, "image/png");
                    _ImageFormats.Add(ImageFormat.Tiff.Guid, "image/tiff");
                    _ImageFormats.Add(ImageFormat.Wmf.Guid, "image/wmf");
                }
                return _ImageFormats;
            }
        }
        #endregion

        #region Public Methods
        public static string GetMimeType(FileUpload mageUploadControl)
        {
            if (mageUploadControl.HasFile && mageUploadControl.PostedFile != null)
            {
                string extention = Path.GetExtension(mageUploadControl.PostedFile.FileName).ToLower();
                string MIMEType = "image/" + extention.Replace(".", "");
                return MIMEType;
            }
            else
                return null;
        }

        public static byte[] GetUploadedPicture(FileUpload imageUploadControl)
        {
            byte[] thePicture = null;
            if (imageUploadControl.HasFile && imageUploadControl.PostedFile != null)
            {
                if (ImageFormats.ContainsValue(GetMimeType(imageUploadControl)))
                {
                    long size = imageUploadControl.PostedFile.InputStream.Length;
                    if (size < int.MaxValue)
                    {
                        byte[] ImageBytes = new byte[size];
                        imageUploadControl.PostedFile.InputStream.Read(ImageBytes, 0, (int)size);
                        thePicture = ImageBytes;
                    }
                    else
                        throw new Exception(string.Format("Image is too big. Images must be smaller than {0} btyes in size.",
                                                          int.MaxValue));
                }
                else
                {
                    throw new Exception("Invalid file type uploaded - only picture files are allowed.");
                }
            }
            return thePicture;
        }
        #endregion
    }
}