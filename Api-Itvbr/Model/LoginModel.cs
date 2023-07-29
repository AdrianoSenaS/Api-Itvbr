using System;
using System.Data;
namespace Api_Itvbr.Model
{
	public class LoginModel
	{
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        private static List<LoginModel> loginModels = new List<LoginModel>();
        private static List<DataRow> ?dataRows;
        private static string Table = "Usuarios";
        private static string Columns = "nome, email, senha";


        public static List<LoginModel> GetLoginUser(LoginModel login)
        {
            dataRows = Db.GetData(Table).AsEnumerable().ToList();
            dataRows.ForEach(r =>
            {
                if (r.Field<string>("email") == login.Email && r.Field<string>("senha") == login.Senha)
                {
                    loginModels.Add(new LoginModel
                    {
                        Id = r.Field<int>("id"),
                        Nome = r.Field<string>("nome"),
                        Email = r.Field<string>("email"),
                        Senha = r.Field<string>("senha")
                    });
                }
            });
            return loginModels;
            
        }

    }
}

