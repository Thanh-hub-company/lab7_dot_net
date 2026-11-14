using System.Collections.Generic;

namespace QLSinhVien.Common
{
    public class ValidationResult
    {
        public List<string> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors.Count == 0; }
        }

        public ValidationResult()
        {
            Errors = new List<string>();
        }

        public void AddError(string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                Errors.Add(errorMessage);
            }
        }

        public string ToFormattedMessage()
        {
            if (IsValid)
            {
                return string.Empty;
            }

            return "Vui lòng kiểm tra lại các thông tin sau:\r\n- " + string.Join("\r\n- ", Errors);
        }
    }
}