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
    class BitMap : BaseGeometry
    {


		// Because we're adding a texture, we modify the vertex array to include texture coordinates.
		// Texture coordinates range from 0.0 to 1.0, with (0.0, 0.0) representing the bottom left, and (1.0, 1.0) representing the top right
		// The new layout is three floats to create a vertex, then two floats to create the coordinates
		private readonly float[] vertices =
        {
            // Position         Texture coordinates
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // top left
        };

		float[] texCoords = {
			0.0f, 0.0f,  // lower-left corner  
			1.0f, 0.0f,  // lower-right corner
			1.0f, 1.0f,  // top-right corner
			0.0f, 1.0f  // top-left corner
		};

		uint[] indices = {  // note that we start from 0!
			0, 1, 3,   // first triangle
			1, 2, 3    // second triangle
		};

		int IBO; // Index Buffer Object
		int VBO; // Vertex Buffer Object
		int VAO; // Vertex Array Object
		Shader shader;
		Texture texture;

		public BitMap(ref Window win) : base(win, GeoType.BitMap)
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

			shader = new Shader("..\\..\\shaders\\bitmapshader.vert", "..\\..\\shaders\\bitmapshader.frag");
			shader.Use();

			texture = new Texture("c:\\desktop\\NewFile.bmp");
			texture.Use();

			//texture = new Texture(Color.Orange, Color.Black, "This\r\nIs\r\nSome\r\nNew\r\nText", new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular));
			//texture.Use();

			VAO = GL.GenVertexArray();
			GL.BindVertexArray(VAO);

			GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, IBO);

			// Because there's now 5 floats between the start of the first vertex and the start of the second,
			// we modify this from 3 * sizeof(float) to 5 * sizeof(float).
			// This will now pass the new vertex array to the buffer.
			var vertexLocation = shader.GetAttribLocation("aPosition");
			GL.EnableVertexAttribArray(vertexLocation);
			GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

			// Next, we also setup texture coordinates. It works in much the same way.
			// We add an offset of 3, since the first vertex coordinate comes after the first vertex
			// and change the amount of data to 2 because there's only 2 floats for vertex coordinates
			var texCoordLocation = shader.GetAttribLocation("aTexCoord");
			GL.EnableVertexAttribArray(texCoordLocation);
			GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);


		}

		public override void RenderFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			GL.BindVertexArray(VAO);

			GL.Color3(0.2f, 0.3f, 0.3f);
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
			GL.BlendEquationSeparate(BlendEquationMode.Max, BlendEquationMode.FuncAdd);
			GL.Enable(EnableCap.Texture2D);
			// GL.Color3(Color.Red);

			texture.Use();
			shader.Use();

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
			texture.Dispose();
		}
    }
}
