using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyIslandHelper.Web.Net46.Core
{
	/// <summary>
	/// Class for checking null or empty
	/// </summary>
	public static class Guard
	{
		/// <summary>
		/// Throw ArgumentNullException if value is null
		/// </summary>
		public static void ForNull<T>([ValidatedNotNull] T value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		/// <summary>
		/// Throw ArgumentNullException if value is null
		/// </summary>
		/// <returns>The original not null value</returns>
		public static T NotNull<T>([ValidatedNotNull] T value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}

			return value;
		}

		/// <summary>
		/// Throw ArgumentNullException if value is null or empty
		/// </summary>
		public static void ForNullOrEmpty([ValidatedNotNull] string value, string name)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException(name);
			}
		}

		/// <summary>
		/// Throws exceptions if collection is null or empty
		/// </summary>
		/// <returns>The original not null and not empty value</returns>
		public static void ForNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}

			if (!value.Any())
			{
				throw new ArgumentException(FormattableString.Invariant($"{name} collection is empty."));
			}
		}

		/// <summary>
		/// Throw ArgumentNullException if value is null or empty
		/// </summary>
		/// <returns>The original not null and not empty value</returns>
		public static string NotNullOrEmpty([ValidatedNotNull] string value, string name)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException(name);
			}

			return value;
		}

		/// <summary>
		/// Throws exceptions if collection is null or empty
		/// </summary>
		/// <returns>The original not null and not empty value</returns>
		public static IEnumerable<T> NotNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}

			if (!value.Any())
			{
				throw new ArgumentException(FormattableString.Invariant($"{name} collection is empty."));
			}

			return value;
		}
	}

	/// <summary>
	/// Attribute to inform FxCop that this method can be applied for checking parameters
	/// </summary>
	sealed class ValidatedNotNullAttribute : Attribute { }
}