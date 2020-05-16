using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace Graphics.src
{
    class Window : GameWindow
    {
        private BaseGeometry mGeo = null;

        public Window(int width, int height, string title) : 
        	base(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, 
                DisplayDevice.Default, 3, 3, GraphicsContextFlags.Default) { }
       
        public void SetGeometry(BaseGeometry BG)
        {
			BG.Start(new EventArgs());
            mGeo = BG;
        }

		protected override void OnLoad(EventArgs e)
		{
			if (mGeo != null) mGeo.Start(new EventArgs());

			base.OnLoad(e);
		}

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (mGeo != null) mGeo.RenderFrame(e);

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (mGeo != null) mGeo.FrameUpdate(e);

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (mGeo != null) mGeo.Resize(e);

            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            if (mGeo != null) mGeo.Dispose(e);
            
            base.OnUnload(e);
        }
    }
}
