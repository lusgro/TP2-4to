public class Persona
{
   public int dni{get; private set;}
   public string apellido{get; set;}
   public string nombre{get; set;}
   public DateTime fechaNacimiento{get; set;}
   public string email{get; set;}

   public Persona(int dni, string ape, string nom, DateTime fnac, string email)
   {
      this.dni = dni;
      this.apellido = ape;
      this.nombre = nom;
      this.fechaNacimiento = fnac;
      this.email = email;
   }

   static int obtenerEdad(DateTime fechaNacimiento)
   {
      DateTime fechaActual = DateTime.Now;
      int edad = fechaActual.Year - fechaNacimiento.Year;
      if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
         edad--;
      return edad;
   }

   static bool puedeVotar(DateTime fechaNacimiento)
   {
      return obtenerEdad(fechaNacimiento) >= 16;
   }
}