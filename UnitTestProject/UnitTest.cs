using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestMethod1 ( )
		{
			string filepath = @"C:\Users\Mike\Documents\visual studio 2012\Projects\SplittingTheBill\UnitTestProject\Resources\SampleData.txt";

			System.Collections.Generic.List<string> list = new List<string> ( );

			list.Add ( "($1.99)" );
			list.Add ( "($8.01)" );
			list.Add ( "$10.01" );

			list.Add ( "$0.98" );
			list.Add ( "($0.98)" );

			// compare output to expected
			using ( var writer = new System.IO.StringWriter ( ) )
			{
				using ( var reader = new System.IO.StringReader ( filepath ) )
				{
					Console.SetOut ( writer );

					Console.SetIn ( reader );

					SplittingTheBill.Program.Main ( new string [ 0 ] );

					string line;

					int counter = 0;

					while ( ( line = reader.ReadLine ( ) ) != null )
					{
						if ( line != string.Empty )
						{
							counter++;

							Assert.Equals ( line , list [ counter ] );
						}

						if ( counter == list.Count ) return;
					}
				}
			}
		}
	}
}
