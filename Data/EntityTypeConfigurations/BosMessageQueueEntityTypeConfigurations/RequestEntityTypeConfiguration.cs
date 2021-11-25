using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RabbitMQTest.Data.EntityTypeConfigurations.BosMessageQueueEntityTypeConfigurations
{
    public class RequestEntityTypeConfiguration : IEntityTypeConfiguration<RequestLogs>
    {
        public void Configure(EntityTypeBuilder<RequestLogs> builder)
        {
            builder.ToTable("RequestLogs", "public");

            builder.HasKey(x => x.RowId).HasName("pk_row_id");
            builder.Property(x => x.RowId).HasColumnName("RowId").HasColumnType("INT").HasIdentityOptions(1, 1);
            builder.Property(x => x.Url).HasColumnName("Url").HasColumnType("VARCHAR").IsRequired();
            builder.Property(x => x.Request).HasColumnName("Request").HasColumnType("TEXT").IsRequired();
            builder.Property(x => x.Response).HasColumnName("Response").HasColumnType("TEXT").IsRequired(false);
            builder.Property(x => x.LogDate).HasColumnName("LogDate").HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(false);
        }
    }
}
