using System;
using System.Data;

namespace Api_Itvbr.Model
{
	public class EpisodiosModel
	{
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Nome { get; set; }
        public string? Episodio { get; set; }
        public string? Url { get; set; }
        public string? Temporada { get; set; }
        public string? Descricao { get; set; }
        private static string Table = "Episodios";
        private static string Columns = "image, nome, episodio, url, temporada, descricao";
        private static List<EpisodiosModel> Episodios = new List<EpisodiosModel>();
        private static List<DataRow>? DataRows;



        public static List<EpisodiosModel> GetEpisodios()
        {
            DataRows = Db.GetData(Table).AsEnumerable().ToList();
            DataRows.ForEach(r =>
            {
                Episodios.Add(new EpisodiosModel
                {
                    Id = r.Field<int>("id"),
                    Image = r.Field<string>("image"),
                    Nome = r.Field<string>("nome"),
                    Episodio = r.Field<string>("episodio"),
                    Url = r.Field<string>("url"),
                    Temporada = r.Field<string>("temporada"),
                    Descricao = r.Field<string>("descricao"),
                });
            });
            return Episodios;
        }

        public static List<EpisodiosModel> GetEpisodiosId(int id)
        {
            DataRows = Db.GetDataId(Table, id).AsEnumerable().ToList();
            DataRows.ForEach(r =>
            {
                Episodios.Add(new EpisodiosModel
                {
                    Id = r.Field<int>("id"),
                    Image = r.Field<string>("image"),
                    Nome = r.Field<string>("nome"),
                    Episodio = r.Field<string>("episodio"),
                    Url = r.Field<string>("url"),
                    Temporada = r.Field<string>("temporada"),
                    Descricao = r.Field<string>("descricao"),
                });
            });
            return Episodios;
        }

        public static string InsertEpisodios(EpisodiosModel episodios)
        {
            string query = $"'{episodios.Image}', '{episodios.Nome}', '{episodios.Episodio}', '{episodios.Url}', '{episodios.Temporada}', '{episodios.Descricao}'";
            return Db.InsertData(Table, Columns, query).ToString();
        }

        public static string UpdateEpisodiosId(EpisodiosModel episodios, int id)
        {
            string query = $"image='{episodios.Image}', nome='{episodios.Nome}', episodio='{episodios.Episodio}', url='{episodios.Url}', temporada='{episodios.Temporada}', descricao='{episodios.Descricao}'";
            return Db.UpdateDataId(Table, query, id).ToString();
        }

        public static string DeleteEpisodiosId(int id)
        {
            return Db.DeleteDataId(Table, id).ToString();
        }
    }
}

