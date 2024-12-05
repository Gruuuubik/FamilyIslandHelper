namespace FamilyIslandHelper.Api.Helpers
{
	public abstract class BaseHelper
	{
		protected const string MainNamespace = "FamilyIslandHelper.Api";
		public const string ImageExtension = ".png";

		protected BaseHelper(ApiVersion apiVersion)
		{
			Prefix = apiVersion == ApiVersion.v1 ? string.Empty : "_v2";

			FolderWithPictures = $"Pictures{Prefix}";
		}

		protected string Prefix { get; }

		public string FolderWithPictures { get; }
	}
}
