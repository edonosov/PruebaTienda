namespace Tienda
{
    /// <summary>
    /// Representa a un usuario en el sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Contraseña del usuario (privada).
        /// </summary>
        private string Password { get; set; }

        /// <summary>
        /// Rol del usuario (por defecto 'User').
        /// </summary>
        public string Rol { get; set; } = "User";

        /// <summary>
        /// Constructor de la clase Usuario.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <param name="rol">Rol del usuario.</param>
        public Usuario(string nombre, string password, string rol)
        {
            Nombre = nombre;
            Password = password;
            Rol = rol;
        }

        /// <summary>
        /// Valida si la contraseña ingresada es correcta.
        /// </summary>
        /// <param name="password">Contraseña ingresada.</param>
        /// <returns>True si la contraseña es correcta, false en caso contrario.</returns>
        public bool Autenticar(string password)
        {
            return Password == password;
        }
    }
}

