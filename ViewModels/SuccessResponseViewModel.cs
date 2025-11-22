namespace ExaminationSystem.ViewModels
{
    public class SuccessResponseViewModel<T> : ResponseViewModel<T>
    {
        public SuccessResponseViewModel(T Data, string message)
        {
           this.Data = Data;
           Message = message;
           IsSuccess = true;    
           ErrorCode = Models.Enums.ErrorCode.NoError;
        }   
    }
}
