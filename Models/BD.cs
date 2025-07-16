using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace tpNoNum.Models;

public class BD{
    private static string _connectionString = @"Server=localhost;DataBase=Integrantes;Integrated Security=True;TrustServerCertificate=True;";
    public BD(){}
    public List<Integrante> ConseguirIntegrantes(){
        List<Integrante> integrantes = new List<Integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM Integrante";
            integrantes = connection.Query<Integrante>(query).ToList();
        }
        return integrantes;
    }
     public Integrante BuscarIntegrantePorId(int idBuscado){
        Integrante integranteBuscado = null;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM Integrante WHERE id = @pIdBuscado";
            integranteBuscado = connection.QueryFirstOrDefault<Integrante>(query, new {pIdBuscado = idBuscado});
        }
        return integranteBuscado;
    }
    public Integrante BuscarIntegrantePorNombre(string nombreBuscado){
        Integrante integranteBuscado = null;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM Integrante WHERE nombre = @pnombreBuscado";
            integranteBuscado = connection.QueryFirstOrDefault<Integrante>(query, new {pnombreBuscado = nombreBuscado});
        }
        return integranteBuscado;
    }
    public void CambiarContra(string nombre, string nuevaContra)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Integrante SET contra = @pNuevaContra WHERE nombre = @pNombre";
            connection.Execute(query, new { pNuevaContra = nuevaContra, pNombre = nombre });
        }
    }
    public void AgregarIntegrante(string nombre, string contra, string email, DateTime fechaNac, string telefono, string direccion, string rol, string foto, int idGrupo)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = @"
                INSERT INTO Integrante 
                (nombre, contra, email, fechaNac, telefono, direccion, rol, foto, idGrupo)
                VALUES 
                (@pNombre, @pContra, @pEmail, @pFechaNac, @pTelefono, @pDireccion, @pRol, @pFoto, @pIdGrupo)";
                            
            connection.Execute(query, new 
            { pNombre = nombre, pContra = contra, pEmail = email, pFechaNac = fechaNac, pTelefono = telefono, pDireccion = direccion, pRol = rol, pFoto = foto, pIdGrupo = idGrupo});
        }
    }
    public List<Integrante> ObtenerIntegrantesPorGrupo(int idGrupo)
    {
        List<Integrante> integrantes = new List<Integrante>();

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrante WHERE idGrupo = @pIdGrupo";
            integrantes = connection.Query<Integrante>(query, new { pIdGrupo = idGrupo }).ToList();
        }

        return integrantes;
    }
}