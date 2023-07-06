using System;
using System.ComponentModel.DataAnnotations;
using PavilionsApplication.Extentions;
using PavilionsData.PavilionsModel.Tables;
using WPFUserControls;

namespace PavilionsApplication;

public static class Authorization
{
    public static void ValidateEmployee(Employee employee)
    {
        if (employee.Login == string.Empty || employee.Password == string.Empty)
            throw new ValidationException("Поля не могут быть пустыми");
    }
    
    public static Employee? Login(LoginData data)
    {
        var employee = data.MakeEmployee();
        ValidateEmployee(employee);
        
        Employee? res = default(Employee?);
        try
        {
            res = App.DataBase.Context.Login(employee);
            if (res != null)
            {
                if (res.Id_Role != 1)
                    return res; //тут будет переход
                else return null;
            }
            else
            {
                throw new Exception();
            }
        }
        catch
        {
        }

        return res;
    }

    public static void Register(LoginData data)
    {
        var employee = data.MakeEmployee();
        ValidateEmployee(employee);
        
        if (false == App.DataBase.Context.Register(employee))
            throw new Exception();
    }
}