using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBFileRecovery
{
    class Program
    {
        static void Main(string[] args)
        {
            HowToUse();

            Console.WriteLine("Ingrese la Letra del dispositivo USB: ");
            string driveLetter = Console.ReadLine();

            Console.WriteLine(driveLetterCheck(driveLetter));



            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            string command = driveLetter + ":";

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.WriteLine("attrib /d /s -r -h -s *.*");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            Console.Read();
        }

        private static void HowToUse()
        {
            string title = "INSTRUCCIONES";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine(string.Format
                (
                @"1- Inserte el dispositivo USB que desea revisar.
2- Verifique la letra del dispositivo(Ej: F:, G:, etc...).
3- Inserte la letra en la pantalla cuando se le indique.
4- Cuando termine el proceso, abra el dispositivo y compruebe que sus archivos esten ahí.

*Nota: En caso de inconvenientes, puede cerrar y volver a abrir este proceso.
Pulse ENTER para continuar..."));
            Console.ReadKey();
        }

        private static string driveLetterCheck(string driveLetter)
        {
            if (string.IsNullOrEmpty(driveLetter))
            {
                Console.WriteLine(string.Format("Error con la entrada '{0}': Por favor, verifique la letra del dispositivo.", driveLetter));
                Environment.Exit(0);
            }
            return "";
        }
    }
}
