int opcion;

do
{
   Console.ReadKey();
   Console.Clear();
   Console.WriteLine("1. Cargar Nueva Persona");
   Console.WriteLine("2. Obtener Estadísticas del Censo");
   Console.WriteLine("3. Buscar Persona");
   Console.WriteLine("4. Modificar Mail de una Persona");
   Console.WriteLine("5. Salir");
   opcion = Funciones.IngresarEnteroEnRango("Elija opción: ", 1, 5);

   switch (opcion)
   {
      case 1:
         Censo.IngresarPersona();
         break;
      case 2:
         Censo.ObtenerEstadisticas();
         break;
      case 3:
         Censo.BuscarPersona();
         break;
      case 4:
         Censo.ModificarMail();
         break;
   }

} while (opcion != 5);