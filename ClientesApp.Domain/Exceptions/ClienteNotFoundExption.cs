using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Exceptions
{
    public class ClienteNotFoundExption : Exception
    {
        public ClienteNotFoundExption(Guid clienteId) : base($"Cliente com ID {clienteId} não encontrado.")
        {
        }

    }
}
