using System;
using System.Text;

namespace AzureSearch.Quickstart
{
    public partial class Files
    {
        // This implementation of ToString() is only for the purposes of the sample console application.
        // You can override ToString() in your own model class if you want, but you don't need to in order
        // to use the Azure Search .NET SDK.
        public override string ToString()
        {
            var builder = new StringBuilder();

            if (!String.IsNullOrEmpty(FileID))
            {
                builder.AppendFormat("fileID: {0}\n", FileID);
            }

            if (!String.IsNullOrEmpty(FileName))
            {
                builder.AppendFormat("Name: {0}\n", FileName);
            }

            if (!String.IsNullOrEmpty(FileText))
            {
                builder.AppendFormat("FileText: {0}\n", FileText);
            }

            if (!String.IsNullOrEmpty(FilePath))
            {
                builder.AppendFormat("Description: {0}\n", FilePath);
            }

            return builder.ToString();
        }
    }
}
