/**
 * RawBots: an awesome robot game
 * 
 * Copyright 2012 Marc-Andre Moreau <marcandre.moreau@gmail.com>
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this file,
 * You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using OpenTK.Graphics.OpenGL;

namespace Rawbots
{
	public class Terrain
	{
		int width;
		int height;

		public Tile[,] tiles;
		public Tile[,] Tiles { get { return tiles; } }

		public ByteMap collisionMap;
		
		public Terrain(int width, int height)
        {
			bool test = false;
			this.width = width;
			this.height = height;

            tiles = new Tile[this.width, this.height];
			collisionMap = new ByteMap(this.width, this.height);

			if (test)
			{
	            int n = 0;
	
	            for (int i = 0; i < tiles.GetLength(0); i++)
	            {
	                for (int j = 0; j < tiles.GetLength(1); j++)
	                {
	                    switch (n % 4)
	                    {
	                        case 0:
	                            tiles[i, j] = new FloorTile();
	                            break;
							
	                        case 1:
	                            tiles[i, j] = new LightRubblePile();
	                            break;
							
	                        case 2:
	                            tiles[i, j] = new MediumRubblePile();
	                            break;
							
	                        case 3:
	                            tiles[i, j] = new HeavyRubblePile();
	                            break;
	                    }
	
	                    n++;
	                }
	            }
			}
			else
			{
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                    {
                        tiles[i, j] = new FloorTile();
                    }
                }
			}

			GenerateCollisionMap();
		}

		public void GenerateCollisionMap()
		{
			byte[,] bytes = collisionMap.Bytes;

			for (int i = 0; i < collisionMap.Width; i++)
			{
				for (int j = 0; j < collisionMap.Height; j++)
				{
					if (tiles[i, j].IsCollideable())
					{
						bytes[i, j] = ByteMap.TRUE;
					}
					else
					{
						bytes[i, j] = ByteMap.FALSE;
					}
				}
			}
		}

		public ByteMap CollisionMap
		{
			get { return collisionMap; }
		}

		public void SetRenderMode(RenderMode renderMode)
        {
			for (int i = 0; i < tiles.GetLength(0); i++)
			{
				for (int j = 0; j < tiles.GetLength(1); j++)
				{
					tiles[i, j].SetRenderMode(renderMode);
				}
			}
        }

		public void ShowTextures()
		{
			for (int i = 0; i < tiles.GetLength(0); i++)
			{
				for (int j = 0; j < tiles.GetLength(1); j++)
				{
					tiles[i, j].ShowTextures();
				}
			}
		}

		public void HideTextures()
		{
			for (int i = 0; i < tiles.GetLength(0); i++)
			{
				for (int j = 0; j < tiles.GetLength(1); j++)
				{
					tiles[i, j].HideTextures();
				}
			}
		}

        public void SetTile(Tile tile, int x, int y)
        {
            tiles[x, y] = tile;
			GenerateCollisionMap();
        }

        public int GetWidth()
        {
            return tiles.GetLength(0);
        }

        public int GetHeight()
        {
            return tiles.GetLength(1);
        }

		public float[][] GetPlane()
		{
			float[][] pPlane = new float[3][];

			pPlane[0] = new float[] { 0.0f, 0.0f, 0.0f };
			pPlane[1] = new float[] { tiles.Length * tiles[0, 0].GetWidth(), 0.0f, 0.0f};
			pPlane[2] = new float[] { 0.0f, tiles.Length * tiles[0, 0].GetWidth(), 0.0f};

			return pPlane;
		}

		public void Render()
		{
			int width, height;

			GL.PushMatrix();
			GL.LineWidth(2.5f);

			width = GetWidth();
			height = GetHeight();

			GL.Color3(0.3f, 0.3f, 0.3f);

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					tiles[i, j].Render();
					GL.Translate(0.0f, 0.0f, -1.0f);
				}

				GL.Translate(1.0f, 0.0f, height * 1.0f);
			}

			GL.Translate(width * -1.0f, 0.0f, 0.0f);

			GL.LineWidth(1.0f);
			GL.PopMatrix();
		}
	}
}
