/**
 * RawBots: an awesome robot game
 * 
 * Copyright 2012 Marc-Andre Moreau <marcandre.moreau@gmail.com>
 * Copyright 2012 Mark Foo Bonasoro <foo_mark@q8ismobile.com>
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this file,
 * You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Rawbots
{
	public abstract class RobotPart : Model
	{
        public CubeModel debugCube;
        public bool debug;

		public RobotPart()
		{
            debugCube = new CubeModel();
            debugCube.SetRenderMode(RenderMode.WIRE);
            debugCube.SetWireColor(1.0f, 1.0f, 1.0f);
            debug = true;
		}
		
		public void Push()
		{
			GL.PushMatrix();
		}
		
		public void Pop()
		{
			GL.PopMatrix();
		}
		
		public void RenderAll()
		{
			Push();
			Render();
			Pop();
		}

        public void RenderDebugCube()
        {
            debugCube.render(1.0f);
        }

		public abstract void Render();
	}
}

