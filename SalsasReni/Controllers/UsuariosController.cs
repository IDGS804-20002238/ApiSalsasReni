using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalsasReni.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly MyDbContext _context;

    public UsuariosController(MyDbContext context)
    {
        _context = context;
    }

    // Endpoint para iniciar sesión (login)
    [HttpPost("login")]
    public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest request)
    {
        try
        {
            // Buscar el usuario por email y contraseña
            var usuario = await _context.Usuarios
                .Where(u => u.Email == request.Email && u.Contrasenia == request.Contrasenia)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado o credenciales incorrectas.");
            }

            return Ok(usuario); // Retorna todo el usuario, incluyendo la dirección y el rol
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }


    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    }
}
