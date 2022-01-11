using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace list_with_coma
{
    class Program
    {
        static void Main(string[] args)
        {
            string directorioActual = Directory.GetCurrentDirectory();
            Console.WriteLine("Renombre el archivo de origen a: origen.txt");
            Console.WriteLine("presione una tecla para continuar\n");
            Console.ReadKey();

            string docPath = directorioActual + @"\";
            string FileToRead = "origen.txt";
            
            Console.WriteLine("El archivo de salida sera parte-XX.txt");
            //string FileToWrite = "Parte-.txt";
            Console.WriteLine("presione una tecla para continuar\n");
            Console.ReadKey();

            // creando el array de strings leidos 
            string[] lines = File.ReadAllLines(FileToRead);



            //------------------------------------------------
            ArrayList miArrayConComillas = new ArrayList();
            ArrayList miArraySinComillas = new ArrayList();

            //concatenando con comillas                  
            for (int i = 0; i < lines.Length; i++)
            {
                string nuevo = string.Concat("'",lines[i],"'",",");

                miArrayConComillas.Add(nuevo);
            }

            //concatenando sin comillas
            for (int i = 0; i < lines.Length; i++)
            {
                string nuevo = string.Concat(lines[i],",");

                miArraySinComillas.Add(nuevo);
            }
            //------------------------------------------------




            //------------------------------------------------
            int cantidadRegistrosPorArchivo = 1000;
            int numero_archivos = (int)((miArrayConComillas.Count / cantidadRegistrosPorArchivo) + 1);

            Console.WriteLine($"Se van a crear {numero_archivos} archivos secuenciales");
            Console.WriteLine("presione una tecla para continuar\n");
            Console.ReadKey();
            //------------------------------------------------


            //------------------------------------------------
            int secuencia_nombre = 0;
            

            while (secuencia_nombre < numero_archivos)
            {
                int limiteFor = (secuencia_nombre + 1) * cantidadRegistrosPorArchivo;


                if (limiteFor > miArrayConComillas.Count)
                {
                    limiteFor = miArrayConComillas.Count;
                }


                string destinationFileName = directorioActual + @"\" + $"Parte-{secuencia_nombre}.txt";
                
                using (var destiNationFile = new StreamWriter(string.Format(destinationFileName, secuencia_nombre + 1)))
                {
                    
                   for (int i = secuencia_nombre * cantidadRegistrosPorArchivo; i < limiteFor ; i++)
                   {
                    destiNationFile.WriteLine(miArrayConComillas[i]);

                   }

                }
                secuencia_nombre++;
            }


            Console.WriteLine("proceso terminado presione una tecla para salir");
            Console.ReadKey();
        }
    }
}
