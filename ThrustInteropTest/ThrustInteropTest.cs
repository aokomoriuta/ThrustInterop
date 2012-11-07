﻿using System;
using System.Runtime.InteropServices;

namespace LWisteria.ThrustInterop
{
	static class ThrustInteropTestMain
	{
		const string DLL_NAME = "ThrustInterop.dll";

		[DllImport(DLL_NAME)]
		static extern IntPtr Create(int size);

		[DllImport(DLL_NAME)]
		static extern void Fill(IntPtr vec, int size, double value);

		[DllImport(DLL_NAME)]
		static extern void CopyTo(IntPtr vec, double[] array, int size);

		[DllImport(DLL_NAME)]
		static extern void Delete(IntPtr vec);

		const int N = 13;

		static int Main()
		{
			IntPtr vec = Create(N);

			Fill(vec, N, 9.56);

			var array = new double[N];
			CopyTo(vec, array, N);

			foreach(var value in array)
			{
				Console.WriteLine(value);
			}

			Delete(vec);

			return Environment.ExitCode;
		}
	}
}