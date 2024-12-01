using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FamilyIslandHelper.Api.Helpers
{
	public class ClassHelper : BaseHelper
	{
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
