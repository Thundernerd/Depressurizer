﻿#region License

//     This file (VrSupport.cs) is part of Depressurizer.
//     Copyright (C) 2018  Martijn Vegter
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Depressurizer.Models
{
	public struct VrSupport
	{
		#region Fields

		[DefaultValue(null)]
		[XmlElement("Headset")]
		public List<string> Headsets;

		[DefaultValue(null)]
		[XmlElement("Input")]
		public List<string> Input;

		[DefaultValue(null)]
		[XmlElement("PlayArea")]
		public List<string> PlayArea;

		#endregion
	}
}