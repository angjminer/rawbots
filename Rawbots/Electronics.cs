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
	public class Electronics : RobotPart
	{
		private float cylinderRadius;
		private float cylinderHeight;
		private CylinderModel cylinder;
		
		private float hemisphereRadius;
		private HemisphereModel hemisphere;
		
		public Electronics()
		{
			/*
			 * This module increases weapon accuracy, giving a notional added
			 * range of 3 miles to each weapon type, Advance warning of attack
			 * contributes to the slightly increased resistance to damage from
			 * enemy fire when this unit is fitted.
			 */
			
			cylinderRadius = 0.4f;
			cylinderHeight = 0.4f;
			cylinder = new CylinderModel();
			cylinder.setColor(0.4f, 0.5f, 0.6f);
			
			hemisphereRadius = 0.3f;
			hemisphere = new HemisphereModel(hemisphereRadius);
			hemisphere.setColor(0.5f, 0.3f, 0.5f);
		}
		
        public override void setRenderMode(RenderMode renderMode)
        {
			cylinder.setRenderMode(renderMode);
			hemisphere.setRenderMode(renderMode);
        }
		
		public override void Render()
		{
			/* cylinder */
			
			GL.PushMatrix();
			
			GL.Translate(0.0, cylinderHeight, 0.0);
			GL.Rotate(90, 1.0, 0.0, 0.0);
			cylinder.render(cylinderRadius, cylinderHeight, 50, 50);
			
			GL.PopMatrix();
	
			/* hemisphere */
			
			GL.PushMatrix();
			
			GL.Translate(0.0, cylinderHeight + hemisphereRadius, 0.0);
			GL.Rotate(225, 0.0, 0.0, 1.0);
			hemisphere.render();
			
			GL.PopMatrix();
		}
	}
}

