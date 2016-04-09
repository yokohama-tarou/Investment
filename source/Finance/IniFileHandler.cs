using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Finance
{
	public class IniFileHandler
	{
		[DllImport( "KERNEL32.DLL" )]
		public static extern uint
		  GetPrivateProfileString( string lpAppName,
		  string lpKeyName, string lpDefault,
		  StringBuilder lpReturnedString, uint nSize,
		  string lpFileName );

		[DllImport( "KERNEL32.DLL",
			EntryPoint = "GetPrivateProfileStringA" )]
		public static extern uint
		  GetPrivateProfileStringByByteArray( string lpAppName,
		  string lpKeyName, string lpDefault,
		  byte[] lpReturnedString, uint nSize,
		  string lpFileName );

		[DllImport( "KERNEL32.DLL" )]
		public static extern uint
		  GetPrivateProfileInt( string lpAppName,
		  string lpKeyName, int nDefault, string lpFileName );

		[DllImport( "KERNEL32.DLL" )]
		public static extern uint WritePrivateProfileString(
		  string lpAppName,
		  string lpKeyName,
		  string lpString,
		  string lpFileName );

		public static double GetPrivateProfileDouble( string lpAppName,
		  string lpKeyName, string lpDefault,
		  StringBuilder lpReturnedString, uint nSize,
		  string lpFileName )
		{
			GetPrivateProfileString(lpAppName, lpKeyName, "0", lpReturnedString, nSize,lpFileName);
			return Convert.ToDouble( lpReturnedString.ToString() );
		}
	}

}
