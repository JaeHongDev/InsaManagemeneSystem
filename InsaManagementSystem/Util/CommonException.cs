using System;

namespace InsaManagementSystem.Util
{
    public class CommonException : Exception
    {
        private ErrorMessage _message;

        public CommonException(ErrorMessage message)
        {
            _message = message;
        }

        public ErrorMessage GetMessage()
        {
            return _message;
        }
    }

    public class ErrorDictionary
    {
        private const string DidNotExistsDataCode = "001";
        private const string DidNotExistsDataMessage = "데이터가 존재하지 않습니다";
        private const string ExistsDataCode = "002";
        private const string ExistsDataMessage = "해당 데이터는 이미 존재합니다";

        public static ErrorMessage DID_NOT_EXISTS_DATA()
        {
            return new ErrorMessage
            {
                Code = DidNotExistsDataCode,
                Message = DidNotExistsDataMessage
            };
        }

        public static ErrorMessage EXISTS_DATA()
        {
            return new ErrorMessage
            {
                Code = ExistsDataCode,
                Message = ExistsDataMessage
            };
        }
    }

    public class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }

        protected bool Equals(ErrorMessage other)
        {
            return Code == other.Code && Message == other.Message;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ErrorMessage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Code != null ? Code.GetHashCode() : 0) * 397) ^ (Message != null ? Message.GetHashCode() : 0);
            }
        }
    }
}