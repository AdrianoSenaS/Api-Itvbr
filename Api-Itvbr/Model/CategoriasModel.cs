using System;
using System.Data;
namespace Api_Itvbr.Model
{
	public class CategoriasModel
	{
		public int? Id { get; set; }
		public string? Nome { get; set; }
        private static List<CategoriasModel> categorias = new List<CategoriasModel>();
		private static List<DataRow> ?rows;
        private static string Table = "categorias";
		private static string Columns = "nome";


		public static List<CategoriasModel> GetCategoriasModels()
		{
			rows = Db.GetData(Table).AsEnumerable().ToList();
			rows.ForEach(r =>
			{
				categorias.Add(new CategoriasModel
				{
					Id = r.Field<int>("id"),
					Nome = r.Field<string>("nome")
				});
			});
			return categorias;
		}

		public static List<CategoriasModel> GetCategoriasModelsId(int id)
		{
            rows = Db.GetDataId(Table, id).AsEnumerable().ToList();
			rows.ForEach(r =>
			{
				categorias.Add(new CategoriasModel
				{
					Id = r.Field<int>("id"),
					Nome = r.Field<string>("nome")
				}) ;
			});
            return categorias;
        }

		public static string InsertCategoriasModels(CategoriasModel categorias)
		{
			string value = $"'{categorias.Nome}'";	
			return Db.InsertData(Table, Columns, value).ToString();
        }

		public static string UpdateCategoriasModels(CategoriasModel categorias, int id)
		{
			string query = $"nome='{categorias.Nome}'";
			return Db.UpdateDataId(Table, query, id).ToString(); ;
		}


		public static string DeleteCategoriasModels(int id)
		{
			return Db.DeleteDataId(Table, id).ToString();
		}
	}
}

