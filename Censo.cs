public static class Censo
{
   public static Dictionary<int, Persona> diccionarioPersonas{get; set;} = new Dictionary<int, Persona>();

   public static bool VerificarDni(int dni)
   {
      bool existeDni = diccionarioPersonas.ContainsKey(dni);
      return existeDni;
   }

   public static Persona IngresarDatos(int dni)
   {
         string apellido = Funciones.IngresarTexto("Ingresar apellido: ");
         string nombre = Funciones.IngresarTexto("Ingresar nombre: ");
         DateTime fechaNacimiento = Funciones.IngresarFecha("Ingresar fecha de nacimiento (aaaa/mm/dd): ");
         string email = Funciones.IngresarTexto("Ingresar email: ");
         return new Persona(dni, apellido, nombre, fechaNacimiento, email);
   }

   public static void ModificarPersona(int dni)
   {
      Console.WriteLine($"Modifica a {dni}");
      Persona persona = IngresarDatos(dni);
      diccionarioPersonas[dni] = persona;
   }

   public static void IngresarPersona()
   {
      int dni = Funciones.IngresarEntero("Ingresar DNI: ");
      bool existeDni = VerificarDni(dni);
      if (existeDni) ModificarPersona(dni);
      else
      {
         Persona persona = IngresarDatos(dni);
         diccionarioPersonas.Add(dni, persona);
      }
   }

   public static void ObtenerEstadisticas()
   {
      if (diccionarioPersonas.Count == 0) Console.WriteLine("Aún no se ingresaron personas en la lista.");
      else {
         bool puedeVotar;
         int contMayores = 0;
         int edadObj;
         int totalEdades = 0;
         foreach (Persona obj in diccionarioPersonas.Values)
         {
            puedeVotar = obj.puedeVotar();
            if (puedeVotar) contMayores++;

            edadObj = obj.obtenerEdad();
            totalEdades += edadObj;
         }
         Console.WriteLine("Estadisticas del censo:");
         Console.WriteLine("Cantidad de personas: " + diccionarioPersonas.Count);
         Console.WriteLine("Cantidad de personas habilitadas para votar: " + contMayores); 
         Console.WriteLine("Promedio de edad: " + totalEdades / diccionarioPersonas.Count);
      }
   }

   public static void BuscarPersona()
   {
      int dni = Funciones.IngresarEntero("Ingresar DNI: ");
      bool existeDni = VerificarDni(dni);
      if (existeDni) Console.WriteLine($"Dni: {dni}, Apellido: {diccionarioPersonas[dni].apellido}, Nombre: {diccionarioPersonas[dni].nombre}, Fecha de nacimiento: {diccionarioPersonas[dni].fechaNacimiento}, Email: {diccionarioPersonas[dni].email}");
      
      else Console.WriteLine("No se encuentra el DNI");
   }

   public static void ModificarMail()
   {
      int dni = Funciones.IngresarEntero("Ingresar DNI: ");
      bool existeDni = VerificarDni(dni);
      if (existeDni)
      {
         string email = Funciones.IngresarTexto("Ingresar nuevo email: ");
         diccionarioPersonas[dni].email = email;
      }
      else Console.WriteLine("No se encuentra el DNI");
   }
}