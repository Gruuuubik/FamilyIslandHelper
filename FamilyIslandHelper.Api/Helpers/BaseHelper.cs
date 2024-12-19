using System.IO;
using System.Reflection;

namespace FamilyIslandHelper.Api.Helpers
{
	public abstract class BaseHelper
	{
		protected const string MainNamespace = "FamilyIslandHelper.Api";
		public const string ImageExtension = ".png";

		protected BaseHelper(ApiVersion apiVersion)
		{
			Assembly = Assembly.GetExecutingAssembly();
			Prefix = apiVersion == ApiVersion.v1 ? string.Empty : "_v2";

			FolderWithPictures = $"Pictures{Prefix}";
		}

		protected string Prefix { get; }

		public string FolderWithPictures { get; }

		protected Assembly Assembly { get; }

		protected MemoryStream GetImageStreamByImagePath(string imagePath)
		{
			using (var stream = Assembly.GetManifestResourceStream(imagePath.Replace("\\", ".")))
			{
				var memoryStream = new MemoryStream();
				stream.CopyTo(memoryStream);
				memoryStream.Position = 0;

				return memoryStream;
			}
		}
	}
}
