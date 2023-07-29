using System;
using System.Data;
namespace Api_Itvbr.Model
{
	public class GeneroModel
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		private static string Table = "genero";
		private static string Columns = "nome";
        private static List<GeneroModel> generos = new List<GeneroModel>();
		private static List<DataRow> ?DataRows;


        public static List<GeneroModel> GetGeneros()
		{
			DataRows = Db.GetData(Table).AsEnumerable().ToList();
			DataRows.ForEach(r =>
			{
				generos.Add(new GeneroModel
				{
					Id = r.Field<int>("id"),
					Nome = r.Field<string>("nome")
				});
			});
			return generos;
		}

		public static List<GeneroModel> GetGenerosId(int id)
		{
			DataRows = Db.GetDataId(Table, id).AsEnumerable().ToList();
			DataRows.ForEach(r =>
			{
				generos.Add(new GeneroModel
				{
					Id = r.Field<int>("id"),
					Nome = r.Field<string>("nome")
				}) ;
			});
			return generos;
		}

		public static string InsertGenero(GeneroModel genero)
		{
			string query = $"'{genero.Nome}'";
			return Db.InsertData(Table, Columns,query).ToString();
		}

		public static string UpdateGeneroId(GeneroModel genero, int id)
		{
			string query = $"nome='{genero.Nome}'";
			return Db.UpdateDataId(Table, query, id).ToString();
		}

		public static string DeleteGeneroId(int id)
		{
			return Db.DeleteDataId(Table, id).ToString();
		}
	}
}

