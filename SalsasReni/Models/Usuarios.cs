namespace SalsasReni.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }

        // Relaciones con otras tablas
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }

}
