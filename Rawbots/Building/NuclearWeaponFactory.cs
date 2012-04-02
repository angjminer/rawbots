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

namespace Rawbots
{
	public class NuclearWeaponFactory : Factory
	{
		public NuclearWeaponFactory() : base()
		{
			robotPart = new NuclearWeapon();
		}
		
		public NuclearWeaponFactory(int x, int y) : base(x, y)
		{
			robotPart = new NuclearWeapon();
		}
	}
}
