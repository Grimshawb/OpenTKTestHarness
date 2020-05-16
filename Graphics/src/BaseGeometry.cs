using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace Graphics.src
{
    abstract class BaseGeometry
    {
        protected Window m_Win;
        private GeoType mGeoType;

        public GeoType GeometryType
        {
            get
            {
                return mGeoType;
            }
        }

        public BaseGeometry(Window window, GeoType type)
        {
            m_Win = window;
            mGeoType = type;
        }
        public virtual void Start(EventArgs e) { }
        public virtual void FrameUpdate(FrameEventArgs e) { }
        public virtual void RenderFrame(FrameEventArgs e) { }
        public virtual void Resize(EventArgs e) 
        {
            GL.Viewport(0, 0, m_Win.Width, m_Win.Height);
            //m_Win.base.OnResize(e);
        }
        public virtual void Dispose(EventArgs e) { }
    }

}
