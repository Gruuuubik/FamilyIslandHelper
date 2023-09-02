using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FamilyIslandHelper.Api.Helpers
{
	public static class ClassHelper
	{
		private const string MainNamespace = "FamilyIslandHelper.Api";

		internal static IEnumerable<Type> GetClasses(string nameSpace)
		{
			var assembly = Assembly.Load(MainNamespace);

			return assembly.GetTypes().Where(type => type.Namespace == nameSpace);
		}

		internal static IEnumerable<string> GetClassesNames(string nameSpace)
		{
			return GetClasses(nameSpace).Select(type => type.Name);
		}
	}
}
