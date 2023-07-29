using System;
using System.Data;
using Api_Itvbr.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api_Itvbr.Model
{
	public class ModelFilmes
	{
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Nome { get; set; }
        public string? Genero { get; set; }
        public string? Categoria { get; set; }
        public string? Descricao { get; set; }
        public string? UrlVideo { get; set; }
        private static List<ModelFilmes> filmes = new List<ModelFilmes>();
        private static List<DataRow> ?rows;
        private static string Table = "filmes";
        private static string  Columns = "image, nome, genero, categoria, descricao, url";

        public static List<ModelFilmes> GetModelFilmes()
        {
            rows = Db.GetData(Table).AsEnumerable().ToList();
            rows.ForEach(r =>
            {
                filmes.Add(new ModelFilmes
                {
                    Id = r.Field<int>("id"),
                    Image = r.Field<string>("image"),
                    Nome = r.Field<string>("nome"),
                    Genero = r.Field<string>("genero"),
                    Categoria = r.Field<string>("categoria"),
                    Descricao = r.Field<string>("descricao"),
                    UrlVideo = r.Field<string>("url")
                });

            });
            return filmes;
        }

        public static List<ModelFilmes> GetModelFilmesId(int id)
        {
            rows = Db.GetDataId(Table, id).AsEnumerable().ToList();
            rows.ForEach(r =>
            filmes.Add(new ModelFilmes
            {
                Id = r.Field<int>("id"),
                Image = r.Field<string>("image"),
                Nome = r.Field<string>("nome"),
                Genero = r.Field<string>("genero"),
                Categoria = r.Field<string>("categoria"),
                Descricao = r.Field<string>("descricao"),
                UrlVideo = r.Field<string>("url")
            }));
            return filmes;
        }

        public static string PostFilmes(ModelFilmes filme)
        { 
            string values = $"'{filme.Image}','{filme.Nome}', '{filme.Genero}', '{filme.Categoria}', '{filme.Descricao}', '{filme.UrlVideo}'";
            return Db.InsertData(Table, Columns, values).ToString();

        }

        public static string UpdateModelFilmes(ModelFilmes filmes, int id)
        {
            string query = $"image='{filmes.Image}', nome='{filmes.Nome}', genero='{filmes.Genero}', categoria='{filmes.Categoria}', descricao='{filmes.Descricao}', url='{filmes.UrlVideo}'";
            return Db.UpdateDataId(Table, query, id).ToString();
        }

        public static string DeleteModelFilmes(int id)
        {
            return Db.DeleteDataId(Table, id).ToString();
        }

    }
}

