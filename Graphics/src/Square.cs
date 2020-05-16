using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsTest.src;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Graphics.src
{
    class Square : BaseGeometry
    {

        float[] vertices = {
			 0.5f,  0.5f, 0.0f,  // top right
			 0.5f, -0.5f, 0.0f,  // bottom right
			-0.5f, -0.5f, 0.0f,  // bottom left
			-0.5f,  0.5f, 0.0f   // top left
		};

		uint[] indices = {  // note that we start from 0!
			0, 1, 3,   // first triangle
			1, 2, 3    // second triangle
		};

		int IBO; // Index Buffer Object
		int VBO; // Vertex Buffer Object
		int VAO; // Vertex Array Object
		Shader shader;


		public Square(ref Window Win) : base(Win, GeoType.Square)
		{
		}


		/// <summary>Graphical Event Handling</summary>
		public override void FrameUpdate(FrameEventArgs e)
		{
			// Get states from OpenTK
			OpenTK.Input.KeyboardState input = OpenTK.Input.Keyboard.GetState();
			OpenTK.Input.MouseState mouse = OpenTK.Input.Mouse.GetState();

			// Keyboard
			if (input.IsKeyDown(OpenTK.Input.Key.Escape)) m_Win.Exit();

			// Mouse
			if (mouse.X > m_Win.Location.X && mouse.X < (m_Win.Location.X + m_Win.Size.Width) &&
				(mouse.Y > m_Win.Location.Y && mouse.Y < (m_Win.Location.Y + m_Win.Size.Height)))
			{

			}

		}

		public override void Start(EventArgs e)
		{
			GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

			VBO = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

			IBO = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);
			GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

			shader = new Shader("..\\..\\shaders\\triangleshader.vert", "..\\..\\shaders\\triangleshader.frag");
			shader.Use();

			VAO = GL.GenVertexArray();
			GL.BindVertexArray(VAO);

			GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);

			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
			GL.EnableVertexAttribArray(0);

		}

		public override void RenderFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			shader.Use();
			GL.BindVertexArray(VAO);
			GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
			m_Win.Context.SwapBuffers();

		}

		public override void Dispose(EventArgs e)
		{
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
			GL.BindVertexArray(0);
			GL.UseProgram(0);

			GL.DeleteBuffer(VBO);
			GL.DeleteVertexArray(VAO);
			shader.Dispose();
		}

    }
}
