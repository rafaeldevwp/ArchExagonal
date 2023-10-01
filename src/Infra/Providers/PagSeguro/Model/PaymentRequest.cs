namespace Infra.Providers.PagSeguro.Model
{
    public class PaymentRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Currency { get; set; }
        public string ItemId1 { get; set; }
        public string ItemDescription1 { get; set; }
        public string ItemAmount1 { get; set; }
        public string ItemQuantity1 { get; set; }
        public string ItemWeight1 { get; set; }
        public string Reference { get; set; }
        public string SenderName { get; set; }
        public string SenderAreaCode { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string ShippingType { get; set; }
        public string ShippingAddressStreet { get; set; }
        public string ShippingAddressNumber { get; set; }
        public string ShippingAddressComplement { get; set; }
        public string ShippingAddressDistrict { get; set; }
        public string ShippingAddressPostalCode { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressState { get; set; }
        public string ShippingAddressCountry { get; set; }
    }
}