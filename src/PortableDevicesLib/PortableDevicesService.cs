/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 05.11.2012
 * Time: 19:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using PortableDevicesLib.Domain;
using System.Collections.Generic;

namespace PortableDevicesLib
{

    public interface PortableDevicesService
    {
        
        IList<PortableDevice> Devices { get; }
        
    }

}
