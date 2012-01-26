using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Rawbots
{
	public class PhasersWeapon : Weapon
	{
		public PhasersWeapon()
		{
		}
		
		public override int getCost()
		{
			return 4;
		}
		
		public override int getRange()
		{
			return 10;
		}
		
		public override int getLethality()
		{
			return 4;
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

