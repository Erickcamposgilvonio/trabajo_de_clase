using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajo
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Sistema de Gestion de notas");
            Console.WriteLine("***************************");
        }

        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Alcanzó la capacidad máxima.");
                return;
            }
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingrese la nota [0-20]: ");
                if (double.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error, volver a ingresar la nota [0-20]");
            }

            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("¡Estudiante registrado con éxito!");
        }

        static public void Mostrar()
        {
            Console.WriteLine("****** LISTADO ORIGINAL ******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            Console.WriteLine("\tNOMBRE \t\tNOTAS");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("\t" + nombres[i] + "\t\t" + notas[i]);
            }
        }

        static public void buscar_estudiante()
        {
            Console.WriteLine("****** BUSCAR ESTUDIANTE ******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("Estudiante encontrado:");
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado...");
        }

        static public void Modificar_estudiante()
        {
            Console.WriteLine("****** MODIFICAR ESTUDIANTE ******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiante registrado.");
                return;
            }
            Console.Write("Ingresar nombre del estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    encontrado = true;
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota [0-20]: ");
                        if (double.TryParse(Console.ReadLine(), out nueva_nota) && nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada...");
                            break;
                        }
                        Console.WriteLine("Error, nota no válida [0-20].");
                    }
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado...");
        }

        static public void burbuja_ascendente()
        {
            Console.WriteLine("****** ORDENAMIENTO ASCENDENTE ******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        double temp_notas = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_notas;

                        string temp_nombres = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombres;
                    }
                }
            }
            Mostrar();
        }

        static public void ordenar_descendente()
        {
            Console.WriteLine("****** ORDENAMIENTO DESCENDENTE (Mayor a Menor) ******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    // Condición cambiada a '<' para ordenar de mayor a menor
                    if (notas[j] < notas[j + 1])
                    {
                        double temp_notas = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_notas;

                        string temp_nombres = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombres;
                    }
                }
            }
            Mostrar();
        }

        static public void promedio_y_maxima()
        {
            Console.WriteLine("****** PROMEDIO Y NOTA MÁXIMA ******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            double suma = 0;
            double maxNota = notas[0];
            string estudianteMax = nombres[0];

            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];
                if (notas[i] > maxNota)
                {
                    maxNota = notas[i];
                    estudianteMax = nombres[i];
                }
            }

            double promedio = suma / contador;

            Console.WriteLine($"Promedio general del curso: {promedio:F2}");
            Console.WriteLine($"Nota máxima: {maxNota} (Estudiante: {estudianteMax})");
        }

        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 8)
            {
                Console.WriteLine("\n************* MENU PRINCIPAL ****************");
                Console.WriteLine("[1] Registrar estudiantes");
                Console.WriteLine("[2] Buscar estudiantes");
                Console.WriteLine("[3] Modificar nota");
                Console.WriteLine("[4] Mostrar lista sin ordenar");
                Console.WriteLine("[5] Mostrar reporte ordenado por burbuja (Ascendente)");
                Console.WriteLine("[6] Mostrar ordenado de mayor a menor (Descendente)");
                Console.WriteLine("[7] Promedio y nota máxima");
                Console.WriteLine("[8] Salir");
                Console.Write("Ingresar opción: ");

                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error, ingresar un valor numérico.");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();
                Titulo();

                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        Modificar_estudiante();
                        break;
                    case 4:
                        Mostrar();
                        break;
                    case 5:
                        burbuja_ascendente();
                        break;
                    case 6:
                        ordenar_descendente();
                        break;
                    case 7:
                        promedio_y_maxima();
                        break;
                    case 8:
                        Console.WriteLine("¡Gracias por usar el sistema!");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta..!!");
                        break;
                }

                if (opc != 8)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}