using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Rawbots
{
	public class AntiGravChassis : Chassis
	{
		public AntiGravChassis()
		{
			/*
			 * By far the best system, it simply flies over the
			 * ground whatever its difficulties. This is the
			 * only chassis that can span ravines!
			 */
		}
		
		public override void Render()
		{
			GL.Begin(BeginMode.Triangles);

			GL.Color3(1.0f, 1.0f, 0.0f);
			GL.Vertex3(-1.0f, -1.0f, 4.0f);
			GL.Color3(1.0f, 0.0f, 0.0f);
			GL.Vertex3(1.0f, -1.0f, 4.0f);
			GL.Color3(0.2f, 0.9f, 1.0f);
			GL.Vertex3(0.0f, 1.0f, 4.0f);
			
			GL.End();
		}
	}
}

