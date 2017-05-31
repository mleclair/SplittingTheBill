using System;
using System.IO;

namespace SplittingTheBill
{
	/// <summary>
	/// 
	/// </summary>
	public class Program
	{
		public static void Main ( string [ ] args )
		{
			string filepath = Console.ReadLine ( );

			try
			{
				filepath = Path.GetFullPath ( filepath );

				string directory = Path.GetDirectoryName ( filepath );

				CalculateSplits ( filepath );
			}
			catch ( System.Exception ex )
			{
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filepath"></param>
		static void CalculateSplits ( string filepath )
		{
			try
			{
				System.IO.StreamReader file = new System.IO.StreamReader ( filepath );

				int participantCount = 0 ,
					expenseCount = 0;

				decimal tripTotal = 0 ,
						itemAmount = 0 ,
						splitOwing = 0 ,
						outstanding = 0;

				string line;

				while ( ( line = file.ReadLine ( ) ) != null )
				{
					if ( line != "0" && int.TryParse ( line , out participantCount ) )
					{
						if ( participantCount > 0 )
						{
							decimal [ ] participantExpenses = new decimal [ participantCount ];

							while ( participantCount > 0 )
							{
								if ( int.TryParse ( line = file.ReadLine ( ) , out expenseCount ) )
								{
									while ( expenseCount > 0 )
									{
										line = file.ReadLine ( );

										itemAmount = Convert.ToDecimal ( line );

										participantExpenses [ participantCount - 1 ] += itemAmount;

										tripTotal += itemAmount;

										expenseCount--;
									}

									if ( participantCount == 1 )
									{
										// write splits
										splitOwing = tripTotal / participantExpenses.Length;

										for ( int i = participantExpenses.Length - 1 ; i > -1 ; i-- )
										{
											outstanding = splitOwing - participantExpenses [ i ];

											Console.WriteLine (
													string.Format (
															( outstanding < 0 ? "(${0})" : "${0}" ) ,
																	Math.Round ( outstanding , 2 ) ) );
										}

										tripTotal = 0;

										Console.WriteLine ( string.Empty );
									}
								}

								participantCount--;
							}
						}
					}
				}

				file.Close ( );
			}
			catch ( System.Exception ex )
			{
				throw ex;
			}
		}
	}
}
