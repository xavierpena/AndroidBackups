﻿#region License
/*
PortableDeviceGuids.cs
Copyright (C) 2009 Vincent Lainé
 
This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace PortableDevicesLib.Domain
{

    /// <summary>
    /// Consts from wpd.h
    /// </summary>
    public static class DeviceGUIDS
    {
        public static Guid GUID_DEVINTERFACE_WPD = new Guid(0x6AC27878, 0xA6FA, 0x4155, 0xBA, 0x85, 0xF9, 0x8F, 0x49, 0x1D, 0x4F, 0x33);
        public static Guid GUID_DEVINTERFACE_WPD_PRIVATE = new Guid(0xBA0C718F, 0x4DED, 0x49B7, 0xBD, 0xD3, 0xFA, 0xBE, 0x28, 0x66, 0x12, 0x11);
        public static Guid WPD_EVENT_NOTIFICATION = new Guid(0x2BA2E40A, 0x6B4C, 0x4295, 0xBB, 0x43, 0x26, 0x32, 0x2B, 0x99, 0xAE, 0xB2);
        public static Guid WPD_EVENT_OBJECT_ADDED = new Guid(0xA726DA95, 0xE207, 0x4B02, 0x8D, 0x44, 0xBE, 0xF2, 0xE8, 0x6C, 0xBF, 0xFC);
        public static Guid WPD_EVENT_OBJECT_REMOVED = new Guid(0xBE82AB88, 0xA52C, 0x4823, 0x96, 0xE5, 0xD0, 0x27, 0x26, 0x71, 0xFC, 0x38);
        public static Guid WPD_EVENT_OBJECT_UPDATED = new Guid(0x1445A759, 0x2E01, 0x485D, 0x9F, 0x27, 0xFF, 0x07, 0xDA, 0xE6, 0x97, 0xAB);
        public static Guid WPD_EVENT_DEVICE_RESET = new Guid(0x7755CF53, 0xC1ED, 0x44F3, 0xB5, 0xA2, 0x45, 0x1E, 0x2C, 0x37, 0x6B, 0x27);
        public static Guid WPD_EVENT_DEVICE_CAPABILITIES_UPDATED = new Guid(0x36885AA1, 0xCD54, 0x4DAA, 0xB3, 0xD0, 0xAF, 0xB3, 0xE0, 0x3F, 0x59, 0x99);
        public static Guid WPD_EVENT_STORAGE_FORMAT = new Guid(0x3782616B, 0x22BC, 0x4474, 0xA2, 0x51, 0x30, 0x70, 0xF8, 0xD3, 0x88, 0x57);
        public static Guid WPD_EVENT_OBJECT_TRANSFER_REQUESTED = new Guid(0x8D16A0A1, 0xF2C6, 0x41DA, 0x8F, 0x19, 0x5E, 0x53, 0x72, 0x1A, 0xDB, 0xF2);
        public static Guid WPD_EVENT_DEVICE_REMOVED = new Guid(0xE4CBCA1B, 0x6918, 0x48B9, 0x85, 0xEE, 0x02, 0xBE, 0x7C, 0x85, 0x0A, 0xF9);
        public static Guid WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT = new Guid(0x99ED0160, 0x17FF, 0x4C44, 0x9D, 0x98, 0x1D, 0x7A, 0x6F, 0x94, 0x19, 0x21);
        public static Guid WPD_CONTENT_TYPE_FOLDER = new Guid(0x27E2E392, 0xA111, 0x48E0, 0xAB, 0x0C, 0xE1, 0x77, 0x05, 0xA0, 0x5F, 0x85);
        public static Guid WPD_CONTENT_TYPE_IMAGE = new Guid(0xef2107d5, 0xa52a, 0x4243, 0xa2, 0x6b, 0x62, 0xd4, 0x17, 0x6d, 0x76, 0x03);
        public static Guid WPD_CONTENT_TYPE_DOCUMENT = new Guid(0x680ADF52, 0x950A, 0x4041, 0x9B, 0x41, 0x65, 0xE3, 0x93, 0x64, 0x81, 0x55);
        public static Guid WPD_CONTENT_TYPE_CONTACT = new Guid(0xEABA8313, 0x4525, 0x4707, 0x9F, 0x0E, 0x87, 0xC6, 0x80, 0x8E, 0x94, 0x35);
        public static Guid WPD_CONTENT_TYPE_CONTACT_GROUP = new Guid(0x346B8932, 0x4C36, 0x40D8, 0x94, 0x15, 0x18, 0x28, 0x29, 0x1F, 0x9D, 0xE9);
        public static Guid WPD_CONTENT_TYPE_AUDIO = new Guid(0x4AD2C85E, 0x5E2D, 0x45E5, 0x88, 0x64, 0x4F, 0x22, 0x9E, 0x3C, 0x6C, 0xF0);
        public static Guid WPD_CONTENT_TYPE_VIDEO = new Guid(0x9261B03C, 0x3D78, 0x4519, 0x85, 0xE3, 0x02, 0xC5, 0xE1, 0xF5, 0x0B, 0xB9);
        public static Guid WPD_CONTENT_TYPE_PLAYLIST = new Guid(0x1A33F7E4, 0xAF13, 0x48F5, 0x99, 0x4E, 0x77, 0x36, 0x9D, 0xFE, 0x04, 0xA3);
        public static Guid WPD_CONTENT_TYPE_MIXED_CONTENT_ALBUM = new Guid(0x00F0C3AC, 0xA593, 0x49AC, 0x92, 0x19, 0x24, 0xAB, 0xCA, 0x5A, 0x25, 0x63);
        public static Guid WPD_CONTENT_TYPE_AUDIO_ALBUM = new Guid(0xAA18737E, 0x5009, 0x48FA, 0xAE, 0x21, 0x85, 0xF2, 0x43, 0x83, 0xB4, 0xE6);
        public static Guid WPD_CONTENT_TYPE_IMAGE_ALBUM = new Guid(0x75793148, 0x15F5, 0x4A30, 0xA8, 0x13, 0x54, 0xED, 0x8A, 0x37, 0xE2, 0x26);
        public static Guid WPD_CONTENT_TYPE_VIDEO_ALBUM = new Guid(0x012B0DB7, 0xD4C1, 0x45D6, 0xB0, 0x81, 0x94, 0xB8, 0x77, 0x79, 0x61, 0x4F);
        public static Guid WPD_CONTENT_TYPE_MEMO = new Guid(0x9CD20ECF, 0x3B50, 0x414F, 0xA6, 0x41, 0xE4, 0x73, 0xFF, 0xE4, 0x57, 0x51);
        public static Guid WPD_CONTENT_TYPE_EMAIL = new Guid(0x8038044A, 0x7E51, 0x4F8F, 0x88, 0x3D, 0x1D, 0x06, 0x23, 0xD1, 0x45, 0x33);
        public static Guid WPD_CONTENT_TYPE_APPOINTMENT = new Guid(0x0FED060E, 0x8793, 0x4B1E, 0x90, 0xC9, 0x48, 0xAC, 0x38, 0x9A, 0xC6, 0x31);
        public static Guid WPD_CONTENT_TYPE_TASK = new Guid(0x63252F2C, 0x887F, 0x4CB6, 0xB1, 0xAC, 0xD2, 0x98, 0x55, 0xDC, 0xEF, 0x6C);
        public static Guid WPD_CONTENT_TYPE_PROGRAM = new Guid(0xD269F96A, 0x247C, 0x4BFF, 0x98, 0xFB, 0x97, 0xF3, 0xC4, 0x92, 0x20, 0xE6);
        public static Guid WPD_CONTENT_TYPE_GENERIC_FILE = new Guid(0x0085E0A6, 0x8D34, 0x45D7, 0xBC, 0x5C, 0x44, 0x7E, 0x59, 0xC7, 0x3D, 0x48);
        public static Guid WPD_CONTENT_TYPE_CALENDAR = new Guid(0xA1FD5967, 0x6023, 0x49A0, 0x9D, 0xF1, 0xF8, 0x06, 0x0B, 0xE7, 0x51, 0xB0);
        public static Guid WPD_CONTENT_TYPE_GENERIC_MESSAGE = new Guid(0xE80EAAF8, 0xB2DB, 0x4133, 0xB6, 0x7E, 0x1B, 0xEF, 0x4B, 0x4A, 0x6E, 0x5F);
        public static Guid WPD_CONTENT_TYPE_NETWORK_ASSOCIATION = new Guid(0x031DA7EE, 0x18C8, 0x4205, 0x84, 0x7E, 0x89, 0xA1, 0x12, 0x61, 0xD0, 0xF3);
        public static Guid WPD_CONTENT_TYPE_CERTIFICATE = new Guid(0xDC3876E8, 0xA948, 0x4060, 0x90, 0x50, 0xCB, 0xD7, 0x7E, 0x8A, 0x3D, 0x87);
        public static Guid WPD_CONTENT_TYPE_WIRELESS_PROFILE = new Guid(0x0BAC070A, 0x9F5F, 0x4DA4, 0xA8, 0xF6, 0x3D, 0xE4, 0x4D, 0x68, 0xFD, 0x6C);
        public static Guid WPD_CONTENT_TYPE_MEDIA_CAST = new Guid(0x5E88B3CC, 0x3E65, 0x4E62, 0xBF, 0xFF, 0x22, 0x94, 0x95, 0x25, 0x3A, 0xB0);
        public static Guid WPD_CONTENT_TYPE_SECTION = new Guid(0x821089F5, 0x1D91, 0x4DC9, 0xBE, 0x3C, 0xBB, 0xB1, 0xB3, 0x5B, 0x18, 0xCE);
        public static Guid WPD_CONTENT_TYPE_UNSPECIFIED = new Guid(0x28D8D31E, 0x249C, 0x454E, 0xAA, 0xBC, 0x34, 0x88, 0x31, 0x68, 0xE6, 0x34);
        public static Guid WPD_CONTENT_TYPE_ALL = new Guid(0x80E170D2, 0x1055, 0x4A3E, 0xB9, 0x52, 0x82, 0xCC, 0x4F, 0x8A, 0x86, 0x89);
        public static Guid WPD_FUNCTIONAL_CATEGORY_DEVICE = new Guid(0x08EA466B, 0xE3A4, 0x4336, 0xA1, 0xF3, 0xA4, 0x4D, 0x2B, 0x5C, 0x43, 0x8C);
        public static Guid WPD_FUNCTIONAL_CATEGORY_STORAGE = new Guid(0x23F05BBC, 0x15DE, 0x4C2A, 0xA5, 0x5B, 0xA9, 0xAF, 0x5C, 0xE4, 0x12, 0xEF);
        public static Guid WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE = new Guid(0x613CA327, 0xAB93, 0x4900, 0xB4, 0xFA, 0x89, 0x5B, 0xB5, 0x87, 0x4B, 0x79);
        public static Guid WPD_FUNCTIONAL_CATEGORY_AUDIO_CAPTURE = new Guid(0x3F2A1919, 0xC7C2, 0x4A00, 0x85, 0x5D, 0xF5, 0x7C, 0xF0, 0x6D, 0xEB, 0xBB);
        public static Guid WPD_FUNCTIONAL_CATEGORY_VIDEO_CAPTURE = new Guid(0xE23E5F6B, 0x7243, 0x43AA, 0x8D, 0xF1, 0x0E, 0xB3, 0xD9, 0x68, 0xA9, 0x18);
        public static Guid WPD_FUNCTIONAL_CATEGORY_SMS = new Guid(0x0044A0B1, 0xC1E9, 0x4AFD, 0xB3, 0x58, 0xA6, 0x2C, 0x61, 0x17, 0xC9, 0xCF);
        public static Guid WPD_FUNCTIONAL_CATEGORY_RENDERING_INFORMATION = new Guid(0x08600BA4, 0xA7BA, 0x4A01, 0xAB, 0x0E, 0x00, 0x65, 0xD0, 0xA3, 0x56, 0xD3);
        public static Guid WPD_FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION = new Guid(0x48F4DB72, 0x7C6A, 0x4AB0, 0x9E, 0x1A, 0x47, 0x0E, 0x3C, 0xDB, 0xF2, 0x6A);
        public static Guid WPD_FUNCTIONAL_CATEGORY_ALL = new Guid(0x2D8A6512, 0xA74C, 0x448E, 0xBA, 0x8A, 0xF4, 0xAC, 0x07, 0xC4, 0x93, 0x99);
        public static Guid WPD_OBJECT_FORMAT_PROPERTIES_ONLY = new Guid(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_UNSPECIFIED = new Guid(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_SCRIPT = new Guid(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_EXECUTABLE = new Guid(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_TEXT = new Guid(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_HTML = new Guid(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_DPOF = new Guid(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_AIFF = new Guid(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_WAVE = new Guid(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MP3 = new Guid(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_AVI = new Guid(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MPEG = new Guid(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_ASF = new Guid(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_EXIF = new Guid(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_TIFFEP = new Guid(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_FLASHPIX = new Guid(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_BMP = new Guid(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_CIFF = new Guid(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_GIF = new Guid(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_JFIF = new Guid(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_PCD = new Guid(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_PICT = new Guid(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_PNG = new Guid(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_TIFF = new Guid(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_TIFFIT = new Guid(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_JP2 = new Guid(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_JPX = new Guid(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT = new Guid(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_WMA = new Guid(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_WMV = new Guid(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_WPLPLAYLIST = new Guid(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_M3UPLAYLIST = new Guid(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MPLPLAYLIST = new Guid(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_ASXPLAYLIST = new Guid(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_PLSPLAYLIST = new Guid(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP = new Guid(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST = new Guid(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_VCALENDAR1 = new Guid(0xBE020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_VCARD2 = new Guid(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_VCARD3 = new Guid(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_ICON = new Guid(0x077232ED, 0x102C, 0x4638, 0x9C, 0x22, 0x83, 0xF1, 0x42, 0xBF, 0xC8, 0x22);
        public static Guid WPD_OBJECT_FORMAT_XML = new Guid(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_AAC = new Guid(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_AUDIBLE = new Guid(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_FLAC = new Guid(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_OGG = new Guid(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MP4 = new Guid(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MP2 = new Guid(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_WORD = new Guid(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MHT_COMPILED_HTML = new Guid(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_EXCEL = new Guid(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT = new Guid(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_NETWORK_ASSOCIATION = new Guid(0xB1020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_X509V3CERTIFICATE = new Guid(0xB1030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_WFC = new Guid(0xB1040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_3GP = new Guid(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        public static Guid WPD_OBJECT_FORMAT_ALL = new Guid(0xC1F62EB2, 0x4BB3, 0x479C, 0x9C, 0xFA, 0x05, 0xB5, 0xF3, 0xA5, 0x7B, 0x22);

    }
}
