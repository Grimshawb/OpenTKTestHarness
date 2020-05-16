using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphics.src;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Collections.Specialized;

namespace Graphics
{
    public partial class Form1 : Form
    {
        Window win = null;
        BaseGeometry bg;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);
			this.Shown += (sender, e) => OpenWindow(sender, e);
        }

		private void btnCreate_Click(object sender, EventArgs e)
		{
			if (PrepareNewInstance()) OpenWindow(this, new EventArgs());
		}

		private void OpenWindow(Object sender, EventArgs e)
		{
			if (win != null && win.Exists) win.Close();
			win = null;
			using (win = new Window(860, 640, "GL Graphics"))
			{
				//Run takes a double, which is how many frames per second it should strive to reach.
				//You can leave that out and it'll just update as fast as the hardware will allow it.
				win.Location = new Point(this.Location.X + this.Width + 20, this.Location.Y);
				win.Run(60.0);
			}
		}

        private void btnTriangle_Click(object sender, EventArgs e)
        {
			if (PrepareNewInstance())
			{
				bg = new Triangle(ref win);
				win.SetGeometry(bg);
			}
        }

		private void btnSquare_Click(object sender, EventArgs e)
		{
			if (PrepareNewInstance())
			{
				bg = new Square(ref win);
				win.SetGeometry(bg);
			}
		}

		private void btnTexture_Click(object sender, EventArgs e)
		{
			if (PrepareNewInstance())
			{
				try
				{
					bg = new BitMap(ref win);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Invalid Operation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				win.SetGeometry(bg);
			}
		}

		private void btnImage_Click(object sender, EventArgs e)
		{
			List<OrderedDictionary> Block = new List<OrderedDictionary>();
			OrderedDictionary Lines = new OrderedDictionary();

			Lines.Add("This is a green line" + "\r\n", Color.Green);
			Lines.Add("But this one is not" + "\r\n", Color.Red);

			Block.Add(Lines);

			List<Bitmap> bmps = CreateTextBMP(Block, Color.Transparent, new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular));
			SaveAndOpenBitmap("C:\\Desktop\\NewFile.bmp", bmps[0]);
		}

		protected List<Bitmap> CreateTextBMP(List<OrderedDictionary> Blocks, Color BackColor, Font font)
		{
			
			if (Blocks.Count < 1) return null; // <------- Exit

			List<Bitmap> bitmaps = new List<Bitmap>();

			foreach (OrderedDictionary line in Blocks)
			{
				if (line.Count < 1) continue;
				Bitmap bm = DrawBlock(line, BackColor, font);
				if (bm != null) bitmaps.Add(bm);
			}

			return bitmaps;
		}

		protected Bitmap DrawBlock(OrderedDictionary line, Color BackColor, Font font)
		{

			if (line.Count < 1) return null;

			StringBuilder s = new StringBuilder();
			System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(new Bitmap(10, 10));
			String[] myKeys = new String[line.Count];
			Color[] myValues = new Color[line.Count];
			line.Keys.CopyTo(myKeys, 0);
			line.Values.CopyTo(myValues, 0);

			for (int i = 0; i < line.Count; i++)
			{
				s.Append(myKeys[i]);
			}

			SizeF OverallSize = gr.MeasureString(s.ToString(), font);
			SizeF CharSize = gr.MeasureString(myKeys[0], font);
			s.Clear();
			Bitmap bmp = new Bitmap((int)OverallSize.Width + 2, (int)OverallSize.Height + 2);
			int y = 0;

			using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bmp))
			{
				gfx.Clear(Color.White);
				for (int i = 0; i < line.Count; i++)
				{
					Brush bsh = new SolidBrush(myValues[i]);
					gfx.DrawString(myKeys[i], font, bsh, 0, y); // Draw the specified charecter
					y += (int)(CharSize.Height);
				}
			}

			return bmp;
		}

		protected void SaveAndOpenBitmap(string path, Bitmap bmp)
		{
			ImageFormat format = ImageFormat.Bmp;
			ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
			ImageCodecInfo CodecInfo = null;
			for (int i = 0; i < encoders.Length; i++)
			{
				if (encoders[i].FormatID == format.Guid)
				{
					CodecInfo = encoders[i];
					break;
				}
			}
			System.Drawing.Imaging.Encoder imgEncoder = System.Drawing.Imaging.Encoder.Quality;
			EncoderParameter imgEncoderParameter = new EncoderParameter(imgEncoder, (int)100L);
			EncoderParameters imgEncoderParameters = new EncoderParameters(1);
			imgEncoderParameters.Param[0] = imgEncoderParameter;
			bmp.Save(path, CodecInfo, imgEncoderParameters);
			System.Diagnostics.Process.Start(path); // <--- Opens the image in the default viewer
		}

		private bool PrepareNewInstance()
		{
			if (win == null)
			{
				MessageBox.Show("Create the window first.", "Invalid Operation!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (bg != null)
			{
				bg.Dispose(new EventArgs());
				bg = null;
			}
			return true;
		}
    }
}
