using System;

namespace Biblioteca.Reservas
{
    public class ReservaService
    {
        public bool PuedeReservar(string codigoUsuario, string estadoUsuario, string codigoLibro, bool esReservable, DateTime fechaReserva, bool yaReservado, bool esDiaHabil)
        {
            if (string.IsNullOrWhiteSpace(codigoUsuario)) return false;
            if (estadoUsuario != "Normal") return false;
            if (!esReservable) return false;
            if (!esDiaHabil || yaReservado) return false;
            return true;
        }
    }
}