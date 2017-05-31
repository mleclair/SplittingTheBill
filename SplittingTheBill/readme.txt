Splitting the bill - readme.txt

Author: Michael Albert LeClair, 2017-03-21

Runs as a common windows console app

Problem: Splitting the Bill

A number of friends go camping every year at provincial parks. 
The group agrees in advance to share expenses equally, but it is not practical to have them share every expense as it 
occurs. So individuals in the group pay for particular things, like food, drinks, supplies, the camp site, parking, etc.
After the camping trip, each person’s expenses are tallied and money is exchanged so that the net cost to each is the same.
In the past, this money exchange has been tedious and time consuming. Your job is to compute, from a list of expenses, the
amount of money that each person must pay or be paid.

Input Format:

The input should be read from a text file where the filename is given as the first and only parameter to the Windows console application.

Sample file:
	~\SplittingTheBill\UnitTestProject\Resources\SampleData.txt

Standard input will contain the information for several camping trips. The information for each trip consists of a line
containing a positive integer, n, the number of peopling participating in the camping trip, followed by n groups of inputs,
one for each camping participant.  Each groups consists of a line containing a positive integer, p, the number of
receipts/charges for that participant, followed by p lines of input, each containing the amount, in dollars and cents, for
each charge by that camping participant.  A single line containing 0 follows the information for the last camping trip.

Output Format:

For each camping trip, output one line per participant indicating how much he/she must pay or be paid rounded to the nearest
cent.  If the participant owes money to the group, then the amount is positive.  If the participant should collect money from
the group, then the amount is negative.  Negative amounts should be denoted by enclosing the amount in brackets.  Each trip
should be separated by a blank line.


Files Includes With This Project:

	AssemblyInfo.cs
	App.Config
	Program.cs
	SampleData.txt
	UnitTest.cs


Profiling Results:

	- The biggest performance bottle neck for the program is input file size
	- For high scalability use a memory mapped file to improve performance.

