using System;
using System.Data;
namespace Api_Itvbr.Model
{
	public class SeriesModel
	{
		public int Id { get; set; }
		public string? Image { get; set; }
		public string? Nome { get; set; }
		public string? Categoria { get; set; }
		public string? Genero { get; set; }
		public string? Temporadas { get; set; }
		public string? Descricao { get; set; }
		private static string Table = "Series";
		private static string Columns = "image, nome, categoria, genero, temporadas, descricao";
		private static List<SeriesModel> series = new List<SeriesModel>();
		private static List<DataRow> ?DataRows;



		public static List<SeriesModel> GetSeries()
		{
			DataRows = Db.GetData(Table).AsEnumerable().ToList();
			DataRows.ForEach(r =>
			{
				series.Add(new SeriesModel
				{
					Id = r.Field<int>("id"),
					Image = r.Field<string>("image"),
					Nome = r.Field<string>("nome"),
					Categoria = r.Field<string>("categoria"),
					Genero = r.Field<string>("genero"),
					Temporadas = r.Field<string>("temporadas"),
					Descricao = r.Field<string>("descricao"),
				});
			});
			return series;
		}

		public static List<SeriesModel> GetSeriesId(int id)
		{
            DataRows = Db.GetDataId(Table, id).AsEnumerable().ToList();
            DataRows.ForEach(r =>
            {
                series.Add(new SeriesModel
                {
                    Id = r.Field<int>("id"),
                    Image = r.Field<string>("image"),
                    Nome = r.Field<string>("nome"),
                    Categoria = r.Field<string>("categoria"),
                    Genero = r.Field<string>("genero"),
                    Temporadas = r.Field<string>("temporadas"),
                    Descricao = r.Field<string>("descricao"),
                });
            });
            return series;
		}

		public static string InsertSeries(SeriesModel series)
		{
			string query = $"'{series.Image}', '{series.Nome}', '{series.Categoria}', '{series.Genero}', '{series.Temporadas}', '{series.Descricao}'";
			return Db.InsertData(Table, Columns, query).ToString();
		}

		public static string UpdateSeriesId(SeriesModel series, int id)
		{
            string query = $"image='{series.Image}', nome='{series.Nome}', categoria='{series.Categoria}', genero='{series.Genero}', temporadas='{series.Temporadas}', descricao='{series.Descricao}'";
            return Db.UpdateDataId(Table, query, id).ToString();
		}

		public static string DeleteSeriesId(int id)
		{
			return Db.DeleteDataId(Table, id).ToString();
		}

	}
}

