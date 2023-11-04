using System.Runtime.Serialization;

namespace TalabatG02.Core.Entities.Order_Aggregiation
{
    public enum OrderStatus
    {//int
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "PaymentReceived")]

        PaymentReceived,
        [EnumMember(Value = "PaymentFailed")]

        PaymentFailed


    }
}
