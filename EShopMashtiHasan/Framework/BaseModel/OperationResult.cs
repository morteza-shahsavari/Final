using System;


namespace Framework.BaseModel
{
   public class OperationResult
    {
        public string Operation { get; set; }
        public DateTime OperationDate { get; private set; }
        public bool Success { get;private set; }
        public int RecordID { get; set; }
        public string Message { get; set; }

        public OperationResult(string operation, int recordId)
        {
            Operation = operation;
            OperationDate = DateTime.Now;
            Success = false;
            RecordID = recordId;
            
        }
        public OperationResult(string operation)
        {
            Operation = operation;
            OperationDate = DateTime.Now;
            Success = false;
            

        }

        public OperationResult Failed(string message,int? RecordID)
        {
            this.Message = message;
            this.Success = false;
            if (RecordID!=null)
            {
                this.RecordID = RecordID.Value;
            }
            return this;
        }
        public OperationResult Failed(string message)
        {
            this.Message = message;
            this.Success = false;
            return this;
        }
        public OperationResult Succeed(string message, int? RecordID)
        {
            this.Message = message;
            this.Success = true;
            if (RecordID != null)
            {
                this.RecordID = RecordID.Value;
            }
            return this;
        }
        public OperationResult Succeed(string message)
        {
            this.Message = message;
            this.Success = true;
            return this;
        }
    }
}
