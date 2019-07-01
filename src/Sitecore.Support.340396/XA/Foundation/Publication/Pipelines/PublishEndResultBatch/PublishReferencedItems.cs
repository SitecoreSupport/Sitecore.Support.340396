using Sitecore.Publishing.Service.Pipelines.BulkPublishingEnd;
using System;

namespace Sitecore.Support.XA.Foundation.Publication.Pipelines.PublishEndResultBatch
{
    public class PublishReferencedItems : Sitecore.XA.Foundation.Publication.Pipelines.PublishEndResultBatch.
        PublishReferencedItems
    {
        public PublishReferencedItems(
            Sitecore.XA.Foundation.SitecoreExtensions.Repositories.IDatabaseRepository databaseRepository) : base(
            databaseRepository)
        {
        }

        public new void Process(PublishEndResultBatchArgs args)
        {
            if (args == null || args.JobData == null || args.JobData.Metadata == null ||
                string.IsNullOrEmpty(args.JobData.Metadata["Publish.Options.IncludeRelatedItems"]) ||
                args.JobData.Metadata["Publish.Options.IncludeRelatedItems"].Equals("false", StringComparison.OrdinalIgnoreCase) ||
                args.JobData.PublishType == null ||
                !args.JobData.PublishType.Equals("Single Item", StringComparison.OrdinalIgnoreCase))
                return;
            base.Process(args);
        }
    }
}