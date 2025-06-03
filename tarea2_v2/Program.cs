using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea2
{
    internal class Program
    {
        //Variables globales
        static int cantidadOperarios = 0;
        static int cantidadTecnicos = 0;
        static int cantidadProfesionales = 0;
        static int tipo;

        static float acumuladorOperarios = 0;
        static float acumuladorTecnicos = 0;
        static float acumuladorProfesionales = 0;
        static float horas;
        static float precioHora;
        static float salarioOrdinario;
        static float aumento = 0;
        static float salarioBruto;
        static float deduccion_ccss;
        static float salarioNeto;

        static string continuar;
        static string cedula;
        static string nombre;

        static void Solicita_info() //Solicita la info
        {
            Console.Write("Cédula: ");
            cedula = Console.ReadLine();

            Console.Write("Nombre del empleado: ");
            nombre = Console.ReadLine();

            do
            {
                Console.Write("Tipo empleado (1. Operario, 2. Técnico, 3. Profesional): ");
                tipo = int.Parse(Console.ReadLine());
            } while (tipo < 1 || tipo > 3);

            Console.Write("Cantidad de horas laboradas: ");
            horas = float.Parse(Console.ReadLine());

            Console.Write("Precio por hora: ");
            precioHora = float.Parse(Console.ReadLine());

            salarioOrdinario = horas * precioHora;
        }

        static void Calculos() //Realiza los calculos de salario, aumento y deducciones
        {
            switch (tipo)
            {
                case 1:
                    aumento = salarioOrdinario * 0.15f;
                    cantidadOperarios++;
                    acumuladorOperarios += (salarioOrdinario + aumento) * 0.9083f;
                    break;
                case 2:
                    aumento = salarioOrdinario * 0.10f;
                    cantidadTecnicos++;
                    acumuladorTecnicos += (salarioOrdinario + aumento) * 0.9083f;
                    break;
                case 3:
                    aumento = salarioOrdinario * 0.05f;
                    cantidadProfesionales++;
                    acumuladorProfesionales += (salarioOrdinario + aumento) * 0.9083f;
                    break;
            }

            salarioBruto = salarioOrdinario + aumento;
            deduccion_ccss = salarioBruto * 0.0917f;
            salarioNeto = salarioBruto - deduccion_ccss;
        }

        static void Imprimir_rep1() //Imprime la info del empleado
        {
            Console.WriteLine("DETALLE DEL EMPLEADO");
            Console.WriteLine("Cédula: " + cedula);
            Console.WriteLine("Nombre del empleado: " + nombre);
            Console.WriteLine("Tipo de empleado: " + tipo);
            Console.WriteLine("Salario por hora: " + precioHora);
            Console.WriteLine("Cantidad de horas: " + horas);
            Console.WriteLine("Salario ordinario: " + salarioOrdinario);
            Console.WriteLine("Aumento: " + aumento);
            Console.WriteLine("Salario bruto: " + salarioBruto);
            Console.WriteLine("Deducción CCSS: " + deduccion_ccss);
            Console.WriteLine("Salario neto: " + salarioNeto);
        }

        static void Imprimir_rep2() //Imprime los reportes estadísticos
        {
            Console.WriteLine("\nESTADISTICA.");

            if (cantidadOperarios > 0)
            {
                Console.WriteLine("\nTIPO OPERARIOS.");
                Console.WriteLine("1. Cantidad de empleados tipo operario: " + cantidadOperarios);
                Console.WriteLine("2. Salario neto empleados tipo operarios; " + acumuladorOperarios);
                Console.WriteLine("3. Promedio de salarios tipo operario: " + (acumuladorOperarios / cantidadOperarios));
            }
            
            if (cantidadTecnicos > 0)
            {
                Console.WriteLine("\nTIPO TÉCNICOS.");
                Console.WriteLine("1. Cantidad de empleados tipo técnicos: " + cantidadTecnicos);
                Console.WriteLine("2. Salario neto empleados tipo técnicos; " + acumuladorTecnicos);
                Console.WriteLine("3. Promedio de salarios tipo técnicos: " + (acumuladorTecnicos / cantidadTecnicos));
            }

            if (cantidadProfesionales > 0)
            {
                Console.WriteLine("\nTIPO PROFESIONAL.");
                Console.WriteLine("1. Cantidad de empleados tipo profesional: " + cantidadProfesionales);
                Console.WriteLine("2. Salario neto empleados tipo profesional: " + acumuladorProfesionales);
                Console.WriteLine("3. Promedio de salarios tipo profesional: " + (acumuladorProfesionales / cantidadProfesionales));
            }

            Console.WriteLine("\n\nFIN DEL PROGRAMA");
        }

        static void Main(string[] args)
        {
            do
            {
                Solicita_info();

                Calculos();

                Imprimir_rep1();
                
                Console.WriteLine("\n¿Desea ingresar otro empleado? (s/n): ");
                continuar = Console.ReadLine().ToLower();
                
            } while (continuar == "s");

            Imprimir_rep2();
        }
    }
}