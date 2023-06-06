using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class TransferOTPRequestModel : TransferRequestModel
    {
        public static new readonly string Cmd = "MONEY_TRANSFER_INSIDE_SMS_OTP";

        [JsonProperty("otp_order_id")]
        public string OrderId { get; set; } = null!;

        [JsonProperty("otp_code")]
        public string OTP { get; set; } = null!;

        public TransferOTPRequestModel() { }

        public TransferOTPRequestModel(string password, string receiver, int amount, string orderId, string otp)
            : base(password, receiver, amount)
        {
            OrderId = orderId;
            OTP = otp;
        }
    }
}
