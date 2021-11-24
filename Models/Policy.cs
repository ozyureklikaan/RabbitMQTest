namespace RabbitMQTest.Models
{
    public class Policy
    {
        public int RowId { get; set; }
        public decimal PolicySerialNo { get; set; }
        public DateTime Version { get; set; }
        public short BmvProductNo { get; set; }
        public decimal BmvAgencyNo { get; set; }
        public string BmvClientNo { get; set; }
        public string BmvInsuredNo { get; set; }
        public string RiscKey { get; set; }
        public string PolicyViewPath { get; set; }
        public short IcCode { get; set; }
        public string IcProductCode { get; set; }
        public string IcPolicyNo { get; set; }
        public short IcRenewalNo { get; set; }
        public short IcEndorsNo { get; set; }
        public short EndorsTypeCode { get; set; }
        public string ProdCancel { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ClientNo { get; set; }
        public string InsuredNo { get; set; }
        public decimal NetPremium { get; set; }
        public decimal GrossPremium { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode{ get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal LcNetPremium { get; set; }
        public decimal LcGrossPremium { get; set; }
        public decimal LcCommissionAmount { get; set; }
        public decimal LcTaxAmount { get; set; }
        public decimal LcAmount { get; set; }
        public bool? Viewed { get; set; }
        public DateTime? ViewedDate { get; set; }
        public byte? PaymentType{ get; set; }
        public short InstalmentCount { get; set; }
        public decimal? InstalmentAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public byte? ProcessType { get; set; }
        public int? RequestId { get; set; }
        public short? SalesType { get; set; }
        public int? VehicleId { get; set; }
        public string TechBmvUserName { get; set; }
        public byte TransferredFrom { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public string FirstUserName { get; set; }
        public DateTime? Last_Update { get; set; }
        public string LastUserName { get; set; }
        public short? OperationId { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }
        public short VersionNo { get; set; }
        public bool IsActive { get; set; }
        public byte PolicyStatus { get; set; }
        public short VbsTransferStatus { get; set; }
        public string ReconciliationUserName { get; set; }
        public short? PaymentStyle { get; set; }
        public string DaskNo { get; set; }
        public short? PaymentStyleInstallment { get; set; }
        public DateTime? PaymentStyleDate { get; set; }
        public string PolicyMaker { get; set; }
    }
}
