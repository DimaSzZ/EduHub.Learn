using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Enums;
using Npgsql;
using Npgsql.TypeMapping;

namespace EduHub.StudentService.Infrastructure.Data.DataSource;

public static class EduHubNpgsqlDataSource 
{
    /// <summary>
    /// Создать NpgsqlDataSource
    /// </summary>
    /// <param name="connectionString">Строка подлючения к БД</param>
    /// <returns>Дата сурс для бд StaffPro</returns>
    public static NpgsqlDataSource Create(string connectionString)
    {
        Guard.Against.NullOrEmpty(connectionString);
        
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        
        RegisterEnums(dataSourceBuilder);
        
        return dataSourceBuilder.Build();
    }
    
    /// <summary>
    /// Регистрация enum'ов для Npgsql data source
    /// </summary>
    /// <param name="dataSourceBuilder">Npgsql data source</param>
    private static void RegisterEnums(INpgsqlTypeMapper dataSourceBuilder)
    {
        dataSourceBuilder.MapEnum<Gender>();
    }
}