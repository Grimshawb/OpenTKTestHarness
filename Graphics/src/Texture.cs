using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
using System.ComponentModel;
using System.Windows.Forms;

namespace Graphics.src
{
	class Texture
	{
		int Handle;

		/// <summary>Load an image directly from file</summary>
		/// <param name="path">Path to file</param>
		public Texture(string path)
		{
			Bitmap bm = LoadTextureFromFile(path);
			if (bm != null) BindBitmap(bm);
		}

		/// <summary>Create an image with text</summary>
		public Texture(Color BackColor, Color ForeColor, string Text, Font font)
		{
			if (!String.IsNullOrEmpty(Text))
			{
				//figure out the size need for the bitmap
				System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(new Bitmap(10, 10));
				SizeF CharSize = gr.MeasureString(Text, font);
				Bitmap bmp = new Bitmap((int)CharSize.Width + 2, (int)CharSize.Height + 2);

				using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bmp))
				{
					//render the string into the bitmap
					Brush bsh = new SolidBrush(ForeColor);
					gfx.Clear(BackColor);
					gfx.DrawString(Text.ToString(), font, bsh, new PointF(0, 0)); // Draw the specified charecter
				}

				if (bmp != null) BindBitmap(bmp);
				
			}
		}

		public static Bitmap LoadTextureFromFile(string path)
		{
			if (File.Exists(path))
			{
				Image Dummy;
				string ext = Path.GetExtension(path);

				if (ext == ".png" || ext == ".bmp" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".tiff")
				{
					Dummy = Image.FromFile(path);
					Dummy.Save("tempimage.bmp", ImageFormat.Bmp);
				}
				else
				{
					throw new Exception("Invalid file type");
				}
			}

			return new Bitmap("tempimage.bmp");
			
		}

		private void BindBitmap(Bitmap bm)
		{
			bm.RotateFlip(RotateFlipType.RotateNoneFlipY); // Image has to be flipped

			GL.GenTextures(1, out Handle);
			GL.BindTexture(TextureTarget.Texture2D, Handle);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMagFilter.Nearest);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bm.Width, bm.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
						  PixelType.UnsignedByte, IntPtr.Zero);


			//bind the texture to the bitmap
			Rectangle R = new Rectangle(0, 0, bm.Width, bm.Height);
			System.Drawing.Imaging.BitmapData data = bm.LockBits(R, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			GL.BindTexture(TextureTarget.Texture2D, Handle);

			GL.TexSubImage2D(TextureTarget.Texture2D, 0, R.X, R.Y, R.Width, R.Height,
				OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
			bm.UnlockBits(data);
		}

		public void Use()
		{
			GL.BindTexture(TextureTarget.Texture2D, Handle);
		}

		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				GL.DeleteTexture(Handle);

				disposedValue = true;
			}
		}

		~Texture()
		{
			GL.DeleteTexture(Handle);
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
