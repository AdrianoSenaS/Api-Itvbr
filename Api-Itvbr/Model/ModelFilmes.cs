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



        public static List<ModelFilmes> GetModelFilmes()
        {
            string query = "filmes";
            List<ModelFilmes> filmes = new List<ModelFilmes>();
            List<DataRow> rows = Db.GetData(query).AsEnumerable().ToList();

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
            string table = "filmes";
            List<ModelFilmes> filmes = new List<ModelFilmes>();
            List<DataRow> rows = Db.GetDataId(table, id).AsEnumerable().ToList();

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
            string filmes = "filmes";
            string table = "image, nome, genero, categoria, descricao, url";
            string values = $"'{filme.Image}','{filme.Nome}', '{filme.Genero}', '{filme.Categoria}', '{filme.Descricao}', '{filme.UrlVideo}'";
            var insertFilmes = Db.InsertData(filmes, table, values);
            if (insertFilmes == true)
            {

                return "Filme cadastrado com sucesso";
            }
            return "Erro ao cadastrar";
        }

        public static string UpdateModelFilmes(ModelFilmes filmes, int id)
        {
            string query = $"image='{filmes.Image}', nome='{filmes.Nome}', genero='{filmes.Genero}', categoria='{filmes.Categoria}', descricao='{filmes.Descricao}', url='{filmes.UrlVideo}'";
            string nome = "filmes";
            var result = Db.UpdateDataId(nome, query, id);
            if (result == true)
            {
                return "Filme atualizado com sucesso!";

            }
            return "Erro ao atualizar filme";
        }

        public static string DeleteModelFilmes(int id)
        {
            string nome = "filmes";
            var result = Db.DeleteDataId(nome, id);

            if (result == true)
            {
                return "Filme deletado com sucesso!";
            }
            return "Erro ao deletar filme";
        }

    }
}

