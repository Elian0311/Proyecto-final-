using System;

class Program
{
    // Definición de la estructura del árbol de decisiones
    class NodoArbol
    {
        public string Pregunta { get; set; }
        public NodoArbol si { get; set; }
        public NodoArbol no { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public int VecesDiagnosticado { get; set; }

        public NodoArbol(string pregunta)
        {
            Pregunta = pregunta;
        }
    }

    static void Main(string[] args)
    {
        // Creación del árbol de decisiones
        NodoArbol nodoGripe = new NodoArbol("¿El paciente tiene fiebre?");
        nodoGripe.si = new NodoArbol("¿El paciente tiene dolor de cabeza?");
        nodoGripe.si.si = new NodoArbol("¿El paciente tiene fatiga?");
        nodoGripe.si.si.si = new NodoArbol("¿El paciente tiene congestión nasal?");
        nodoGripe.si.si.si.si = new NodoArbol("¿El paciente tiene dolor de garganta?")
        {
            Diagnostico = "Gripe",
            Tratamiento = "Descanso, líquidos, medicamentos para reducir la fiebre y aliviar los síntomas."
        };
        nodoGripe.si.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no = new NodoArbol("¿El paciente tiene congestión nasal?");
        nodoGripe.no.si = new NodoArbol("¿El paciente tiene estornudos?");
        nodoGripe.no.si.si = new NodoArbol("¿El paciente tiene dolor de garganta?");
        nodoGripe.no.si.si.si = new NodoArbol("¿El paciente tiene tos?");
        nodoGripe.no.si.si.si.si = new NodoArbol("¿El paciente tiene leve malestar general?")
        {
            Diagnostico = "Resfriado común",
            Tratamiento = "Descanso, líquidos, medicamentos para aliviar la congestión y la tos."
        };
        nodoGripe.no.si.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no = new NodoArbol("¿El paciente tiene dolor facial?");
        nodoGripe.no.no.si = new NodoArbol("¿El paciente tiene presión en los senos paranasales?");
        nodoGripe.no.no.si.si = new NodoArbol("¿El paciente tiene secreción nasal espesa y verde?");
        nodoGripe.no.no.si.si.si = new NodoArbol("¿El paciente tiene congestión nasal?")
        {
            Diagnostico = "Sinusitis",
            Tratamiento = "Analgésicos, descongestionantes, irrigación nasal, humidificadores."
        };
        nodoGripe.no.no.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no.no = new NodoArbol("¿El paciente tiene estornudos?");
        nodoGripe.no.no.no.si = new NodoArbol("¿El paciente tiene picazón en los ojos?");
        nodoGripe.no.no.no.si.si = new NodoArbol("¿El paciente tiene congestión nasal?");
        nodoGripe.no.no.no.si.si.si = new NodoArbol("¿El paciente tiene erupciones cutáneas?");
        nodoGripe.no.no.no.si.si.si.si = new NodoArbol("¿El paciente tiene sibilancias?")
        {
            Diagnostico = "Alergia",
            Tratamiento = "Antihistamínicos, descongestionantes, evitación del alérgeno."
        };
        nodoGripe.no.no.no.si.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no.no.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no.no.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no.no.no = new NodoArbol("¿El paciente tiene tos persistente?");
        nodoGripe.no.no.no.no.si = new NodoArbol("¿El paciente tiene producción de esputo?");
        nodoGripe.no.no.no.no.si.si = new NodoArbol("¿El paciente tiene dificultad para respirar?");
        nodoGripe.no.no.no.no.si.si.si = new NodoArbol("¿El paciente tiene fatiga?");
        nodoGripe.no.no.no.no.si.si.si.si = new NodoArbol("El paciente podría tener bronquitis.")
        {
            Diagnostico = "Bronquitis",
            Tratamiento = "Descanso, líquidos, inhaladores broncodilatadores, medicamentos para aliviar la tos."
        };
        nodoGripe.no.no.no.no.si.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");
        nodoGripe.no.no.no.no.si.si.no = new NodoArbol("El paciente podría tener otra enfermedad.");

        // Ejecución del diagnóstico
        Diagnostico(nodoGripe);
    }

    // Método para realizar el diagnóstico interactivo
    static void Diagnostico(NodoArbol nodo)
    {
        Console.WriteLine(nodo.Pregunta);
        string respuesta = Console.ReadLine().ToLower();

        if (respuesta == "si")
        {
            if (nodo.si.Diagnostico != null)
            {
                nodo.si.VecesDiagnosticado++;
                Console.WriteLine($"Diagnóstico: {nodo.si.Diagnostico}");
                Console.WriteLine($"Tratamiento: {nodo.si.Tratamiento}");
                ReiniciarDiagnostico();
            }
            else
            {
                Diagnostico(nodo.si);
            }
        }
        else if (respuesta == "no")
        {
            if (nodo.no.Diagnostico != null)
            {
                nodo.no.VecesDiagnosticado++;
                ReiniciarDiagnostico();
            }
            else
            {
                Diagnostico(nodo.no);
            }
        }
        else
        {
            Console.WriteLine("Respuesta no válida. Por favor, responda 'si' o 'no'.");
            Diagnostico(nodo);
        }
    }

    // Método para reiniciar el diagnóstico
    static void ReiniciarDiagnostico()
    {
        Console.WriteLine("\n¿Desea realizar otro diagnóstico? (si/no)");
        string respuesta = Console.ReadLine().ToLower();
        if (respuesta == "si")
        {
            Main(null);
        }
        else if (respuesta == "no")
        {
            Console.WriteLine("\nGracias por usar nuestro sistema de diagnóstico.");
        }
        else
        {
            Console.WriteLine("Respuesta no válida. Por favor, responda 'si' o 'no'.");
            ReiniciarDiagnostico();
        }
    }
}