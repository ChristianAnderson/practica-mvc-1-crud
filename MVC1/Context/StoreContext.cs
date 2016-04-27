using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVC1.Models;
using System.Web;

namespace MVC1.Context
{
    public class StoreContext: DbContext
    {
        public DbSet<Product> Products { get; set; } //Se llama Products por que son muchos y este atributo nos representara
                                                     // todos los productos de la clase
        // con esas lineas nos creamos la bases de datos
    }
}
