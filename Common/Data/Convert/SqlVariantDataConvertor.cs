using Common.Convert;
using System;

namespace Common.Data.Convert
{
    public class SqlVariantDataConvertor
    {
        public static SqlVariantSupportDataType Convert(int dataType)
        {
            SqlVariantSupportDataType temp;

            switch (dataType)
            {
                case 0:
                    temp = SqlVariantSupportDataType.UniqueIdentifier;
                    break;
                case 1:
                    temp = SqlVariantSupportDataType.Char;
                    break;
                case 2:
                    temp = SqlVariantSupportDataType.Varchar;
                    break;
                case 3:
                    temp = SqlVariantSupportDataType.Nvarchar;
                    break;
                case 4:
                    temp = SqlVariantSupportDataType.Nchar;
                    break;
                case 5:
                    temp = SqlVariantSupportDataType.Int;
                    break;
                case 6:
                    temp = SqlVariantSupportDataType.SmallInt;
                    break;
                case 7:
                    temp = SqlVariantSupportDataType.BigInt;
                    break;
                case 8:
                    temp = SqlVariantSupportDataType.Decimal;
                    break;
                case 9:
                    temp = SqlVariantSupportDataType.Numeric;
                    break;
                case 10:
                    temp = SqlVariantSupportDataType.Bit;
                    break;
                case 11:
                    temp = SqlVariantSupportDataType.Float;
                    break;
                case 12:
                    temp = SqlVariantSupportDataType.Real;
                    break;
                case 13:
                    temp = SqlVariantSupportDataType.Date;
                    break;
                case 14:
                    temp = SqlVariantSupportDataType.Time;
                    break;
                case 15:
                    temp = SqlVariantSupportDataType.DateTime;
                    break;
                case 16:
                    temp = SqlVariantSupportDataType.DateTime2;
                    break;
                case 17:
                    temp = SqlVariantSupportDataType.DatetimeOffset;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported SQL type ");
            }

            return temp;
        }

        public object Convert(object obj,SqlVariantSupportDataType supportType)
        {
            switch (supportType)
            {
                case SqlVariantSupportDataType.UniqueIdentifier:
                    return new Guid(obj.ToString());
                case SqlVariantSupportDataType.Char:
                case SqlVariantSupportDataType.Varchar:
                case SqlVariantSupportDataType.Nchar:
                case SqlVariantSupportDataType.Nvarchar:
                    return obj.ToString();
                case SqlVariantSupportDataType.Int:
                    return Int32.Parse(obj.ToString());
                case SqlVariantSupportDataType.SmallInt:
                    return Int16.Parse(obj.ToString());
                case SqlVariantSupportDataType.BigInt:
                    return Int64.Parse(obj.ToString());
                case SqlVariantSupportDataType.Decimal:
                case SqlVariantSupportDataType.Numeric:
                    return decimal.Parse(obj.ToString());
                case SqlVariantSupportDataType.Bit:
                    return bool.Parse(obj.ToString());
                case SqlVariantSupportDataType.Float:
                    return float.Parse(obj.ToString());
                case SqlVariantSupportDataType.Real:
                    return Single.Parse(obj.ToString());
                case SqlVariantSupportDataType.Date:
                    return ByteConvertor.GetDate(ObjectConvertor.ObjectToByteArray(obj));
                case SqlVariantSupportDataType.Time:
                    return ByteConvertor.GetTime(ObjectConvertor.ObjectToByteArray(obj));
                case SqlVariantSupportDataType.DateTime2:
                    return ByteConvertor.GetDateTime2(ObjectConvertor.ObjectToByteArray(obj));
                case SqlVariantSupportDataType.DatetimeOffset:
                    return ByteConvertor.GetDateTimeOffset(ObjectConvertor.ObjectToByteArray(obj));
            }
            throw new InvalidOperationException("Unsupported SQL type: '" + supportType.ToString() + "'");
        }
    }
}
