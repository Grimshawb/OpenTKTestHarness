using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace GraphicsTest.src
{
	class Shader
	{
		int Handle;
		public Shader(string VertexPath, string FragmentPath)
		{
			string VertexShaderSource;
			int VertexShader;
			int FragmentShader;

			using (StreamReader reader = new StreamReader(VertexPath, Encoding.UTF8))
			{
				VertexShaderSource = reader.ReadToEnd();
			}

			string FragmentShaderSource;

			using (StreamReader reader = new StreamReader(FragmentPath, Encoding.UTF8))
			{
				FragmentShaderSource = reader.ReadToEnd();
			}

			VertexShader = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(VertexShader, VertexShaderSource);

			FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(FragmentShader, FragmentShaderSource);

			GL.CompileShader(VertexShader);

			string infoLogVert = GL.GetShaderInfoLog(VertexShader);
			if (infoLogVert != System.String.Empty)
				System.Console.WriteLine(infoLogVert);

			GL.CompileShader(FragmentShader);

			string infoLogFrag = GL.GetShaderInfoLog(FragmentShader);

			if (infoLogFrag != System.String.Empty)
				System.Console.WriteLine(infoLogFrag);

			Handle = GL.CreateProgram();

			GL.AttachShader(Handle, VertexShader);
			GL.AttachShader(Handle, FragmentShader);

			GL.LinkProgram(Handle);

			GL.DetachShader(Handle, VertexShader);
			GL.DetachShader(Handle, FragmentShader);
			GL.DeleteShader(FragmentShader);
			GL.DeleteShader(VertexShader);
		}

		public void Use()
		{
			GL.UseProgram(Handle);
		}

		public int GetAttribLocation(string attribName)
		{
			return GL.GetAttribLocation(Handle, attribName);
		}

		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				GL.DeleteProgram(Handle);

				disposedValue = true;
			}
		}

		~Shader()
		{
			GL.DeleteProgram(Handle);
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
