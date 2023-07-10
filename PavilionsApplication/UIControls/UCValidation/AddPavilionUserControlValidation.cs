using System;
using System.Linq;

namespace PavilionsApplication.UIControls.UCValidation;

public static class AddPavilionUserControlValidation
{
    public static bool NumberValidate(this string pavilionNumber) =>
        pavilionNumber.Any(_ => Char.IsDigit(_)) && pavilionNumber.Any(_ => Char.IsLetter(_)) &&
        pavilionNumber.Length >= 2 && pavilionNumber.Length <= 3;
    
    
    
}