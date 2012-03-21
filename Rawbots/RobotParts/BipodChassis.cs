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
	public class BipodChassis : Chassis
	{
		//private CubeModel[] mcComponent;
		//private const int TORSO = 0;
		//private const int UPPER_LEG = 1;
		//private const int LOWER_LEG = 2;
		//private const int FOOT = 3;
		//private const int TOTAL_COMPONENTS = 4;

		//private OBJModel model;

		public BipodChassis()
		{
			/*
			 * Slow but cheap and rugged. Can't get over
			 * hills but can cope with rough ground at a pinch!
			 * Best used on flat level ground.
			 */

			//mcComponent = new CubeModel[TOTAL_COMPONENTS];
			//for (int i = 0; i < mcComponent.Length; i++)
			//     mcComponent[i] = new CubeModel();

			//SetHeight(1.0f);
			
			//material = new Material(Material.MaterialType.SHINY_STEEL);
			//for (int i = 0; i < mcComponent.Length; i++)
			//     mcComponent[i].AssignMaterial(material);

			model = new OBJModel(Game.resourcePath + "/Bipod Chassis/Bipod_chassis.obj");
		}
		
		public override void SetRenderMode(RenderMode renderMode)
        {
			//for (int i = 0; i < mcComponent.Length; i++)
			//    mcComponent[i].SetRenderMode(renderMode);
        }

		public override void Render()
		{
            //GL.PushMatrix();
            //GL.Translate(0.0f, 0.5f, 0.0f);
            //GL.Scale(1.0f, 1.0f, 1.0f);
            //RenderDebugCube();
            //GL.PopMatrix();

            //GL.Translate(0.0f, 1.0f, 0.0f);

            //GL.Scale(0.5f, 0.5f, 0.5f);

            //GL.PushMatrix();
            //Scale the width to accomadate the legs and flatten it.
            //GL.Scale(2.0f, 0.25f, 1.0f);
            
            /************************************************************************/
            /* Drawing upper torso                                                  */
            /************************************************************************/

            //Set the gray color
            //mcComponent[0].SetColor(0.8f, 0.8f, 0.8f);
            //mcComponent[0].render(1.0f);

            //Restore back the original scale (1.0f, 1.0f, 1.0f) by multiplying it to give 1.0f for each axis
            //GL.Scale(0.5f, 4.0f, 1.0f);
            //GL.Translate(0.0f, -0.375f - 0.25f, 0.0f);

            //GL.Translate(0.5f, 0.0f, 0.0f);

            //drawLeg();

            //GL.Translate(-1.0f, 0.0f, 0.0f);

            //drawLeg();

            //Team Number
            //GL.PushMatrix();
            //GL.Translate(0.4f, 0.7f, 0.0f);
            //GL.Scale(0.66f, 0.66f, 0.66f);
            //GL.Rotate(90, 1.0f, 0.0f, 0.0f);

            //TeamNumber.Render();
            //GL.PopMatrix();

            //GL.PopMatrix();

			GL.Scale(0.1f, 0.1f, 0.1f);
			model.Render();
		}

		//public void drawLeg()
		//{
		//    GL.PushMatrix();

		//    GL.Rotate(-45.0f, 1.0f, 0.0f, 0.0f); //Rotate the upper leg forwards on the x axis
		//    GL.Scale(0.5f, 1.0f, 0.5f); //Scale down both x,z by half

		//    /************************************************************************/
		//    /* Draw the upper leg                                                   */
		//    /************************************************************************/
		//    mcComponent[UPPER_LEG].SetColor(0.2196f, 0.298f, 0.498f);
		//    mcComponent[UPPER_LEG].render(1.0f);

		//    //Restore original point of transformation
		//    GL.PopMatrix();
		//    GL.PushMatrix();

		//    //Translate the bottom leg down by a half on the y
		//    GL.Translate(0.0f, -0.5f, 0.0f);

		//    GL.Rotate(45.0f, 1.0f, 0.0f, 0.0f); //Rotate the lower leg backwards on the x axis
		//    GL.Scale(0.5f, 1.0f, 0.5f);

		//    /************************************************************************/
		//    /* Draw the lower leg                                                   */
		//    /************************************************************************/
		//    mcComponent[LOWER_LEG].SetColor(0.2196f, 0.298f, 0.498f);
		//    mcComponent[LOWER_LEG].render(1.0f);

		//    //Restore original point of transformation
		//    GL.PopMatrix();
		//    GL.PushMatrix();

		//    GL.Translate(0.0f, -1.0f, 0.0f);
		//    GL.Scale(0.5f, 0.5f, 1.0f);

		//    /************************************************************************/
		//    /* Draw the foot                                                                     */
		//    /************************************************************************/
		//    mcComponent[FOOT].SetColor(0.4f, 0.498f, 0.6f);
		//    mcComponent[FOOT].render(1.0f);

		//    GL.PopMatrix();
		//}
	}
}

