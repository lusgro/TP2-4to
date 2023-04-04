using System.Collections.Generic;

Dictionary<int, Persona> diccionarioPersonas = new Dictionary<int, Persona>();

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
   opcion = IngresarEnteroEnRango("Elija opción: ", 1, 5);

   switch (opcion)
   {
      case 1:
         IngresarPersona();
         break;
      case 2:
         ObtenerEstadisticas();
         break;
      case 3:
         BuscarPersona();
         break;
      case 4:
         ModificarMail();
         break;
   }

} while (opcion != 5);

static int IngresarEntero(string msj)
{
   int entero=-1;
   while (entero == -1)
   {   
      Console.Write(msj);
      int.TryParse(Console.ReadLine(), out entero);
   }
   return entero;
}

static int IngresarEnteroEnRango(string msj, int minimo, int maximo)
{
   int entero;
   entero = IngresarEntero(msj);
   while (entero < minimo || entero > maximo)
   {
      entero = IngresarEntero("ERROR! " + msj);
   }
   return entero;
}

static string IngresarTexto(string msj)
{
   string texto = "";
   while (texto == "")
   {
      Console.Write(msj);
      texto = Console.ReadLine();
   }
   return texto;
}

static DateTime IngresarFecha(string msj)
{
   DateTime fechaDate;
   string fechaCadena = IngresarTexto(msj);
   while (!DateTime.TryParse(fechaCadena, out fechaDate))
   {
      fechaCadena = IngresarTexto("ERROR! " + msj);
   }
   return fechaDate;
}

bool VerificarDni(int dni)
{
   bool existeDni = diccionarioPersonas.ContainsKey(dni);
   return existeDni;
}

void IngresarPersona()
{
   int dni = IngresarEntero("Ingresar DNI: ");
   bool existeDni = VerificarDni(dni);
   if (existeDni) Console.WriteLine("El DNI ya existe");
   else
   {
      string apellido = IngresarTexto("Ingresar apellido: ");
      string nombre = IngresarTexto("Ingresar nombre: ");
      DateTime fechaNacimiento = IngresarFecha("Ingresar fecha de nacimiento (aaaa/mm/dd): ");
      string email = IngresarTexto("Ingresar email: ");
      Persona persona = new Persona(dni, apellido, nombre, fechaNacimiento, email);
      diccionarioPersonas.Add(dni, persona);
   }
}

void ObtenerEstadisticas()
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

void BuscarPersona()
{
   int dni = IngresarEntero("Ingresar DNI: ");
   bool existeDni = VerificarDni(dni);
   if (existeDni) Console.WriteLine($"Dni: {dni}, Apellido: {diccionarioPersonas[dni].apellido}, Nombre: {diccionarioPersonas[dni].nombre}, Fecha de nacimiento: {diccionarioPersonas[dni].fechaNacimiento}, Email: {diccionarioPersonas[dni].email}");
    
   else Console.WriteLine("No se encuentra el DNI");
}

void ModificarMail()
{
   int dni = IngresarEntero("Ingresar DNI: ");
   bool existeDni = VerificarDni(dni);
   if (existeDni)
   {
      string email = IngresarTexto("Ingresar nuevo email: ");
      diccionarioPersonas[dni].email = email;
   }
   else Console.WriteLine("No se encuentra el DNI");
}