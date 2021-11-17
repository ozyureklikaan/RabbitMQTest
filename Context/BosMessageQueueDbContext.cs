namespace RabbitMQTest.Context;

public class BosMessageQueueDbContext : DbContext
{
    public BosMessageQueueDbContext(DbContextOptions<BosMessageQueueDbContext> options) : base(options)
    {
    }

    public virtual DbSet<RequestLogs> RequestLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestLogs>(entity =>
        {
            entity.ToTable("RequestLogs", "public");
            entity.HasKey(x => x.RowId).HasName("pk_row_id");
            entity.Property(x => x.RowId).HasColumnName("RowId").HasColumnType("INT").HasIdentityOptions(1,1);
            entity.Property(x => x.Url).HasColumnName("Url").HasColumnType("VARCHAR").IsRequired();
            entity.Property(x => x.Request).HasColumnName("Request").HasColumnType("TEXT").IsRequired();
            entity.Property(x => x.Response).HasColumnName("Response").HasColumnType("TEXT").IsRequired(false);
            entity.Property(x => x.LogDate).HasColumnName("LogDate").HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(x => x.Description).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired(false);
        });

        base.OnModelCreating(modelBuilder);
    }
}
