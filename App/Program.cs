﻿using App.Repositories;
using Microsoft.Data.SqlClient;

internal class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

    private static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
        ReadUsers(connection);
        //CreateUser();
        //UpdateUser();
        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);

        var users = repository.Get();

        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

    public static void ReadUsersWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);

        var users = repository.GetWithRoles();

        foreach (var user in users)
        {
            Console.WriteLine(user.Name);

            foreach (var role in user.Roles)
            {
                Console.WriteLine($" - {role.Name}");
            }
        }
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);

        var roles = repository.Get();

        foreach (var role in roles)
        {
            Console.WriteLine(role.Name);
        }
    }

    //public static void ReadUser()
    //{
    //    using (var connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        var user = connection.Get<User>(1);

    //        Console.WriteLine(user.Name);
    //    }
    //}

    //public static void CreateUser()
    //{
    //    var user = new User
    //    {
    //        Bio = "Equipe TSS",
    //        Email = "tss.solutions@gmail.com",
    //        Image = "https://...",
    //        Name = "TSS Solutions",
    //        PasswordHash = "HASH",
    //        Slug = "equipe-tss"
    //    };

    //    using (var connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        connection.Insert<User>(user);
    //        Console.WriteLine("Cadastro realizado com sucesso");
    //    }
    //}

    //public static void UpdateUser()
    //{
    //    var user = new User
    //    {
    //        Id = 2,
    //        Bio = "Equipe | TSS",
    //        Email = "tss.solutions@gmail.com",
    //        Image = "https://...",
    //        Name = "TSS - Solutions",
    //        PasswordHash = "HASH",
    //        Slug = "equipe-tss"
    //    };

    //    using (var connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        connection.Update<User>(user);
    //        Console.WriteLine("Atualização realizada com sucesso");
    //    }
    //}

    //public static void DeleteUser()
    //{
    //    using (var connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        var user = connection.Get<User>(2);
    //        connection.Update<User>(user);
    //        Console.WriteLine("Exclusão realizada com sucesso");
    //    }
    //}
}