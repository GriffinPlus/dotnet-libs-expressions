///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;

namespace GriffinPlus.Lib.Expressions
{
	/// <summary>
	/// Helper methods for reading/writing test data sets.
	/// </summary>
	internal static class TestDataHelpers
	{
		/// <summary>
		/// Reads test records for the hash code calculation tests from the specified file.
		/// </summary>
		/// <param name="path">Name of the file to read.</param>
		/// <returns>A list containing the read test records.</returns>
		public static List<TestRecord> ReadTestData(string path)
		{
			List<TestRecord> records = new List<TestRecord>();

			using (FileStream fs = new FileStream(path, FileMode.Open))
			using (StreamReader reader = new StreamReader(fs))
			{
				while (true)
				{
					string line = reader.ReadLine();
					if (line == null) break;
					string[] tokens = line.Split('\t');
					records.Add(new TestRecord()
					{
						Expression = tokens[0],
						HashCode = Convert.ToInt32(tokens[1])
					});
				}

				return records;
			}
		}

		/// <summary>
		/// Writes test records for the hash code calculation tests to the specified file.
		/// </summary>
		/// <param name="path">Name of the file to write to.</param>
		/// <param name="records">Test records to write.</param>
		public static void WriteTestData(string path, IEnumerable<TestRecord> records)
		{
			using (FileStream fs = new FileStream(path, FileMode.Create))
			using (StreamWriter writer = new StreamWriter(fs))
			{
				foreach (var data in records)
				{
					string line = $"{data.Expression,-110}\t{data.HashCode:x08}";
					writer.WriteLine(line);
				}
			}
		}

	}
}
