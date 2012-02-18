﻿/**
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

using Tao.FreeGlut;

using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Rawbots
{
	class Game : GameWindow
	{
		Map map;
		int width;
		int height;
        bool camera = true;
		string baseTitle = "Rawbots";
		
        Camera cam = new Camera(0.0f, 0.0f, 25.0f);

		public Game() : base(800, 600, GraphicsMode.Default, "Rawbots")
		{
			VSync = VSyncMode.On;
            
			Glut.glutInit();
			
			width = 50;
			height = 50;
			map = new Map(width, height);
			
			Robot robot;

            int x = 0;
            int y = 0;
			
			robot = new Robot(x + 1, y + 1);
            robot.AddElectronics(new Electronics());
            map.AddRobot(robot);
			
			robot = new Robot(x + 3, y + 1);
			robot.AddWeapon(new NuclearWeapon());
			map.AddRobot(robot);
			
			robot = new Robot(x + 5, y + 1);
			robot.AddWeapon(new PhasersWeapon());
			map.AddRobot(robot);

            robot = new Robot(x + 7, y + 1);
            robot.AddWeapon(new MissilesWeapon());
            map.AddRobot(robot);

            robot = new Robot(x + 9, y + 1);
            robot.AddWeapon(new CannonWeapon());
            map.AddRobot(robot);

            robot = new Robot(x + 11, y + 1);
            robot.AddChassis(new AntiGravChassis());
            map.AddRobot(robot);

            robot = new Robot(x + 13, y + 1);
            robot.AddChassis(new TrackedChassis());
            map.AddRobot(robot);

            robot = new Robot(x + 15, y + 1);
            robot.AddChassis(new BipodChassis());
            map.AddRobot(robot);

            Tile tile = new LightRubbleTile();
            map.SetTile(tile, x + 17, y + 1);

            tile = new MediumRubbleTile();
            map.SetTile(tile, x + 19, y + 1);

            tile = new HeavyRubbleTile();
            map.SetTile(tile, x + 21, y + 1);

            Pit pit = new Pit();
            pit.setVisible(Pit.NORTH);
            map.SetTile(pit, x + 23, y + 1);

            pit = new Pit();
            pit.setVisible(Pit.EAST);
            map.SetTile(pit, x + 25, y + 1);

            pit = new Pit();
            pit.setVisible(Pit.WEST);
            map.SetTile(pit, x + 27, y + 1);

            pit = new Pit();
            pit.setVisible(Pit.SOUTH);
            map.SetTile(pit, x + 29, y + 1);

            pit = new Pit();
            pit.setVisible(Pit.EAST + Pit.WEST);
            map.SetTile(pit, x + 31, y + 1);

            pit = new Pit();
            pit.setVisible(Pit.NORTH + Pit.SOUTH);
            map.SetTile(pit, x + 33, y + 1);

			Factory factory;
			
			factory = new AntiGravChassisFactory(x + 2, y + 5);
			map.AddFactory(factory);

            factory = new BipodChassisFactory(x + 7, y + 5);
            map.AddFactory(factory);

            factory = new CannonWeaponFactory(x + 12, y + 5);
            map.AddFactory(factory);

            factory = new ElectronicsFactory(x + 17, y + 5);
            map.AddFactory(factory);

            factory = new MissilesWeaponFactory(x + 22, y + 5);
            map.AddFactory(factory);

            factory = new NuclearWeaponFactory(x + 27, y + 5);
            map.AddFactory(factory);

            factory = new PhasersWeaponFactory(x + 32, y + 5);
            map.AddFactory(factory);

            factory = new TrackedChassisFactory(x + 37, y + 5);
            map.AddFactory(factory);

            Base b = new Base(x + 45, y + 5);
            map.AddBase(b);

            Block block = new Block(false, x + 35, y + 1);
            map.AddBlock(block);

            block = new Block(true, x + 37, y + 1);
            map.AddBlock(block);

            BlockSquareHole bsh = new BlockSquareHole(false, x + 39, y + 1);
            map.AddBlock(bsh);

            bsh = new BlockSquareHole(true, x + 41, y + 1);
            map.AddBlock(bsh);

            Boundary boundary = new Boundary();
            map.SetTile(boundary, x + 45, y + 1);

            robot = new Robot(x + 10, y + 10);
            robot.AddChassis(new TrackedChassis());
            robot.AddWeapon(new MissilesWeapon());
            robot.AddElectronics(new Electronics());
            map.AddRobot(robot);

            Console.WriteLine("Press ESC to Quit Program.");
            Console.WriteLine("F1 (Wire/Solid Mode), F2 (Solid Mode), F3 (Wire Mode)");
            Console.WriteLine("F4 (Show XYZ Plane), F5 (Show XZ Plane), F6 (Show XY Plane), F7 (Show Nothing)");
            Console.WriteLine("F11 (Enable Camera), F12 (Disable Camera)");
            
            this.Title = this.baseTitle;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
			GL.Enable(EnableCap.DepthTest);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float) Math.PI / 4, Width / (float) Height, 1.0f, /*64.0f*/120.0f);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref projection);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame(e);

            if (Keyboard[Key.Escape])
                Exit();
            else if (Keyboard[Key.F1])
                map.SetRenderMode(RenderMode.SOLID_WIRE);
            else if (Keyboard[Key.F2])
                map.SetRenderMode(RenderMode.SOLID);
            else if (Keyboard[Key.F3])
                map.SetRenderMode(RenderMode.WIRE);
            else if (Keyboard[Key.F4])
                ReferencePlane.setVisibleAxis(ReferencePlane.XYZ);
            else if (Keyboard[Key.F5])
                ReferencePlane.setVisibleAxis(ReferencePlane.XZ);
            else if (Keyboard[Key.F6])
                ReferencePlane.setVisibleAxis(ReferencePlane.XY);
            else if (Keyboard[Key.F7])
                ReferencePlane.setVisibleAxis(ReferencePlane.NONE);
            else if (Keyboard[Key.F11])
                camera = false;
            else if (Keyboard[Key.F12])
                camera = true;

            if (camera)
            {
                if (Keyboard[Key.Up])
                    cam.moveLoc(0.0f, 0.0f, 1.0f, 0.5f);
                if (Keyboard[Key.Down])
                    cam.moveLoc(0.0f, 0.0f, -1.0f, 0.5f);
                if (Keyboard[Key.Left])
                    cam.moveLoc(-1.0f, 0.0f, 0.0f, 0.5f);
                if (Keyboard[Key.Right])
                    cam.moveLoc(1.0f, 0.0f, 0.0f, 0.5f);

                if (Keyboard[Key.W])
                    cam.rotateLoc(-0.5f, 1.0f, 0.0f, 0.0f);
                if (Keyboard[Key.S])
                    cam.rotateLoc(0.5f, 1.0f, 0.0f, 0.0f);
                if (Keyboard[Key.D])
                    cam.rotateLoc(0.5f, 0.0f, 1.0f, 0.0f);
                if (Keyboard[Key.A])
                    cam.rotateLoc(-0.5f, 0.0f, 1.0f, 0.0f);
                if (Keyboard[Key.Q])
                    cam.rotateLoc(0.5f, 0.0f, 0.0f, 1.0f);
                if (Keyboard[Key.E])
                    cam.rotateLoc(-0.5f, 0.0f, 0.0f, 1.0f);
            }
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
            int startTime = Environment.TickCount & Int32.MaxValue;

			base.OnRenderFrame(e);

			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadMatrix(ref modelview);
			
            //GL.Translate(0.0f, 0.0f, -75.0f);
            //GL.Rotate(45.0f, 1.0f, 1.0f, 0.0f);

            cam.setView();

            ReferencePlane.setDimensions(50, 50);
            ReferencePlane.render();

            map.Render();
			
			GL.Flush();
			
			SwapBuffers();

            int totalTime = (Environment.TickCount & Int32.MaxValue) - startTime;

            int fps = 0;
            
            if (totalTime > 0)
                fps = 1000 / totalTime;
		
            Title = this.baseTitle + " FPS: " + fps;
        }

		[STAThread]
		static void Main()
		{
			using (Game game = new Game())
			{
				game.Run();
			}
		}
	}
}
