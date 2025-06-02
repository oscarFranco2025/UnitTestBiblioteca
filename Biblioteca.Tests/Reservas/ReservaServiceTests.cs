using NUnit.Framework;
using Biblioteca.Reservas;
using System;

namespace Biblioteca.Tests.Reservas
{
    public class ReservaServiceTests
    {
        private ReservaService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ReservaService();
        }

        [Test]
        public void ReservaValida_DebeRetornarTrue()
        {
            var resultado = _service.PuedeReservar("U001", "Normal", "L001", true, DateTime.Now, false, true);
            Assert.IsTrue(resultado);
        }

        [TestCase("", "Normal", "L001", true, true, false)]
        [TestCase("U001", "Sancionado", "L001", true, true, false)]
        public void CasosInvalidos_RetornanFalse(string codUsu, string estUsu, string codLibro, bool esReservable, bool esDiaHabil, bool yaReservado)
        {
            var resultado = _service.PuedeReservar(codUsu, estUsu, codLibro, esReservable, DateTime.Now, yaReservado, esDiaHabil);
            Assert.IsFalse(resultado);
        }
    }
}