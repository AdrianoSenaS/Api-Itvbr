using System;
namespace Api_Itvbr.Model
{
	public class CadastroModel
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Email { get; set; }
		public string? Senha { get; set; }
		private static string Table = "Usuarios";
		private static string Columns = "nome, email, senha";


		public static string InsertUser(CadastroModel cadastro)
		{
			string query = $"'{cadastro.Nome}', '{cadastro.Email}',  '{cadastro.Senha}'";
			return Db.InsertData(Table, Columns, query).ToString();
		}
	}
}

