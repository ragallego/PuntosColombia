using PuntosColombia.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntosColombia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaracion de variables para el proceso general
            int diff = 0;
            int[] arr;
            int[] brr;
            int resultValue = 0;
            int n = 0;
            int m = 0;

            try
            {
                //Validacion de ingreso de tamaño del primer vector
                Console.WriteLine("Tamaño del primer Vector");
                var tv1 = Console.ReadLine();
                int.TryParse(tv1, out resultValue);
                if (resultValue != 0)
                {
                    n = resultValue;
                    resultValue = 0;
                }
                else if (tv1 == "0")
                    Close("El tamaño del primer vector debe ser mayor a cero, presione ENTER para salir");
                else
                    Close("El dato ingresado debe ser númerico, presione ENTER para salir");

                //Validacion de ingreso de tamaño del segundo vector
                Console.WriteLine("Tamaño del segundo vector");
                var tv2 = Console.ReadLine();
                int.TryParse(tv2, out resultValue);
                if (resultValue != 0)
                {
                    m = resultValue;
                    resultValue = 0;
                }
                else if (tv2 == "0")
                    Close("El tamaño del segundo vector debe ser mayor a cero, presione ENTER para salir");
                else
                    Close("El dato ingresado debe ser númerico, presione ENTER para salir");

                // Constraint: n<=m
                if (m < n)
                    Close("La cantidad de datos ingresados, no corresponde al tamaño del vector, presione ENTER para salir");

                // Constraint: 1<=n,m<=2*100000
                if ((n < 1 || n >= 200000) || (m < 1 || m >= 200000))
                    Close("El tamaño de los arreglos deben estar entre 1 y 200000, presione ENTER para salir");

                //Ingreso de los valores del primer vector
                Console.WriteLine("Ingresa los valores del primer arreglo, separados por comas");
                var val = Console.ReadLine().Split(',');
                arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    // Constraint: x intersecion B
                    int tamano = val.Length;
                    if (tamano == n)
                    {
                        int.TryParse(val[i], out resultValue);

                        if (resultValue != 0)
                            arr[i] = resultValue;
                        else if (val[i] == "0")
                            arr[i] = resultValue;
                        else
                            Close("Los valores deben ser numéricos, presione ENTER para salir");
                    }
                    else
                        Close("La cantidad de datos ingresados, no corresponde al tamaño del vector, presione ENTER para salir");

                    resultValue = 0;
                }

                //Ingreso de los valores del segundo vector
                Console.WriteLine("Ingresa los valores del segundo arreglo, separados por comas");
                var val2 = Console.ReadLine().Split(',');
                brr = new int[m];
                for (int i = 0; i < m; i++)
                {
                    // Constraint: x intersecion B
                    int tamano2 = val2.Length;
                    if (tamano2 == m)
                    {
                        int.TryParse(val2[i], out resultValue);

                        if (resultValue != 0)
                            brr[i] = resultValue;
                        else if (val2[i] == "0")
                            brr[i] = resultValue;
                        else
                            Close("Los valores deben ser numéricos, presione ENTER para salir");
                    }
                    else
                        Close("La cantidad de datos ingresados, no corresponde al tamaño del vector, presione ENTER para salir");

                    resultValue = 0;
                }

                // Constraint: 1<=x <=10000
                if ((arr.Where(k => k <= 1 || k >= 10000).Count() > 0) || (brr.Where(k => k <= 1 || k >= 10000).Count() > 0))
                    Close("Los valores de los arreglos deben estar entre 1 y 10000, presione ENTER para salir");

                int[] result = OrdeNumerico.missingNumbers(arr, brr, out diff);

                // Constraint: Xmax - Xmin < 101
                if (diff > 100)
                    Close("La diferencia entre el valor máximo y minimo del segundo arreglo debe ser menor o igual a 100, presione ENTER para salir");

                Close(string.Concat("Los números faltantes son: ", String.Join(" ", result)));
            }
            catch (Exception excepcion)
            {
                Close("El sistema lanzó la siguiente excepción: " + excepcion.Message + " presione ENTER para salir");
            }
        }

        public static void Close(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
