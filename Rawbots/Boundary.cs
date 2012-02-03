﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Rawbots
{
    class Boundary : Tile
    {
        public CubeModel cube;

        public Boundary()
        {
            cube = new CubeModel();
            cube.SetRenderMode(RenderMode.SOLID_WIRE);
        }

        public override void Render()
        {
            base.Render();

            GL.PushMatrix();

            GL.Translate(0.0f, 0.25f, 0.0f);
            GL.Scale(0.5f, 0.5f, 0.5f);
            cube.render(1.0f);

            GL.PopMatrix();
            GL.PushMatrix();

            GL.Translate(0.0f, 0.8f, 0.0f);
            GL.Scale(0.25f, 0.75f, 0.25f);
            cube.render(1.0f);

            GL.PopMatrix();
            GL.PushMatrix();

            GL.Translate(0.0f, 1.0f, 0.0f);
            GL.Scale(0.15f, 1.0f, 0.15f);
            cube.render(1.0f);

            GL.PopMatrix();
        }
    }
}
