namespace Jefflix.NEGOCIO
{
    public class Persona
    {
        //Atributos
        public string? Name { get; set; } 
        public float? Height { get; set; } 
        public int? Age { get; set; } 
        public float Weight { get; set; }
        //Constructor de la clase
        /*
        public Persona(string name, float height, int age, float weight)
        {
            this.Name = name;
            this.Height = height;  
            this.Age = age;
            this.Weight = weight;
        }
        */
        //Metodos
        public string Introduce()
        {
            string greeting = "Hola mi nombre es: " + Name;
            return greeting;
        }

    }
}
