using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RabbitMQTest.Data.EntityTypeConfigurations
{
    public class PolicyEntityTypeConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasKey(x => x.RowId);

            builder.Property(x => x.RowId).HasColumnName("ROW_ID");
            builder.Property(x => x.PolicySerialNo).HasColumnName("POLICY_SERIAL_NO");
            builder.Property(x => x.Version).HasColumnName("VERSION");
            builder.Property(x => x.BmvProductNo).HasColumnName("BMV_PRODUCT_NO");
            builder.Property(x => x.BmvAgencyNo).HasColumnName("BMV_AGENCY_CODE");
            builder.Property(x => x.BmvClientNo).HasColumnName("BMV_CLIENT_NO");
            builder.Property(x => x.BmvInsuredNo).HasColumnName("BMV_INSURED_NO");
            builder.Property(x => x.RiscKey).HasColumnName("RISC_KEY");
            builder.Property(x => x.PolicyViewPath).HasColumnName("POLICY_VIEW_PATH");
            builder.Property(x => x.IcCode).HasColumnName("IC_CODE");
            builder.Property(x => x.IcProductCode).HasColumnName("IC_PRODUCT_CODE");
            builder.Property(x => x.IcPolicyNo).HasColumnName("IC_POLICY_NO");
            builder.Property(x => x.IcRenewalNo).HasColumnName("IC_RENEWAL_NO");
            builder.Property(x => x.IcEndorsNo).HasColumnName("IC_ENDORS_NO");
            builder.Property(x => x.EndorsTypeCode).HasColumnName("ENDORS_TYPE_CODE");
            builder.Property(x => x.ProdCancel).HasColumnName("PROD_CANCEL");
            builder.Property(x => x.BeginDate).HasColumnName("BEGIN_DATE");
            builder.Property(x => x.EndDate).HasColumnName("END_DATE");
            builder.Property(x => x.ApprovedDate).HasColumnName("APPROVED_DATE");
            builder.Property(x => x.ClientNo).HasColumnName("CLIENT_NO");
            builder.Property(x => x.InsuredNo).HasColumnName("INSURED_NO");
            builder.Property(x => x.NetPremium).HasColumnName("NET_PREMIUM");
            builder.Property(x => x.GrossPremium).HasColumnName("GROSS_PREMIUM");
            builder.Property(x => x.CommissionAmount).HasColumnName("COMMISSION_AMOUNT");
            builder.Property(x => x.TaxAmount).HasColumnName("TAX_AMOUNT");
            builder.Property(x => x.Amount).HasColumnName("AMOUNT");
            builder.Property(x => x.CurrencyCode).HasColumnName("CURRENCY_CODE");
            builder.Property(x => x.ExchangeRate).HasColumnName("EXCHANGE_RATE");
            builder.Property(x => x.LcNetPremium).HasColumnName("LC_NET_PREMIUM");
            builder.Property(x => x.LcGrossPremium).HasColumnName("LC_GROSS_PREMIUM");
            builder.Property(x => x.LcCommissionAmount).HasColumnName("LC_COMMISSION_AMOUNT");
            builder.Property(x => x.LcTaxAmount).HasColumnName("LC_TAX_AMOUNT");
            builder.Property(x => x.LcAmount).HasColumnName("LC_AMOUNT");
            builder.Property(x => x.Viewed).HasColumnName("VIEWED");
            builder.Property(x => x.ViewedDate).HasColumnName("VIEWED_DATE");
            builder.Property(x => x.PaymentType).HasColumnName("PAYMENT_TYPE");
            builder.Property(x => x.InstalmentCount).HasColumnName("INSTALLMENT_COUNT");
            builder.Property(x => x.InstalmentAmount).HasColumnName("INSTALLMENT_AMOUNT");
            builder.Property(x => x.AdvanceAmount).HasColumnName("ADVANCE_AMOUNT");
            builder.Property(x => x.ProcessType).HasColumnName("PROCESS_TYPE");
            builder.Property(x => x.RequestId).HasColumnName("REQUEST_ID");
            builder.Property(x => x.SalesType).HasColumnName("SALES_TYPE");
            builder.Property(x => x.VehicleId).HasColumnName("VEHICLE_ID");
            builder.Property(x => x.TechBmvUserName).HasColumnName("TECH_BMV_USER_NAME");
            builder.Property(x => x.TransferredFrom).HasColumnName("TRANSFERRED_FROM");
            builder.Property(x => x.TransferDate).HasColumnName("TRANSFER_DATE");
            builder.Property(x => x.EntryDate).HasColumnName("ENTRY_DATE");
            builder.Property(x => x.FirstUserName).HasColumnName("FIRST_USER_NAME");
            builder.Property(x => x.Last_Update).HasColumnName("LAST_UPDATE");
            builder.Property(x => x.LastUserName).HasColumnName("LAST_USER_NAME");
            builder.Property(x => x.OperationId).HasColumnName("OPERATION_ID");
            builder.Property(x => x.IpAddress).HasColumnName("IP_ADDRESS");
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION");
            builder.Property(x => x.VersionNo).HasColumnName("VERSION_NO");
            builder.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            builder.Property(x => x.PolicyStatus).HasColumnName("POLICY_STATUS");
            builder.Property(x => x.VbsTransferStatus).HasColumnName("VBS_TRANSFER_STATUS");
            builder.Property(x => x.ReconciliationUserName).HasColumnName("RECONCILIATION_USER_NAME");
            builder.Property(x => x.PaymentStyle).HasColumnName("PAYMENT_STYLE");
            builder.Property(x => x.DaskNo).HasColumnName("DASK_NO");
            builder.Property(x => x.PaymentStyleInstallment).HasColumnName("PAYMENT_STYLE_INSTALLMENT");
            builder.Property(x => x.PaymentStyleDate).HasColumnName("PAYMENT_STYLE_DATE");
            builder.Property(x => x.PolicyMaker).HasColumnName("POLICY_MAKER");
        }
    }
}