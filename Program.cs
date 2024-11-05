// See https://aka.ms/new-console-template for more information
using System;
using System.Management;

Console.WriteLine("\n---------------------------------------");
Console.WriteLine("|***************PCSPECS***************|");
Console.WriteLine("---------------------------------------\n");


if (OperatingSystem.IsWindows())
{

    var searcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

    Console.WriteLine("\nSistema Operacional--------------------");
    foreach (var os in searcher.Get())
    {
        Console.WriteLine("Sistema Operacional: " + os["Caption"]);
        Console.WriteLine("Versão: " + os["Version"]);
        Console.WriteLine("Arquitetura: " + os["OSArchitecture"]);
    }

    searcher = new ManagementObjectSearcher("select * from Win32_LogicalDisk");

    Console.WriteLine("\nDisco----------------------------------");
    foreach (var ld in searcher.Get())
    {
        Console.WriteLine("Nome do disco: " + ld["Name"]);
        Console.WriteLine("Tipo: " + ld["DriveType"]);
        Console.WriteLine("Espaço livre: " + (Convert.ToDouble(ld["FreeSpace"]) / 1024 / 1024 / 1024) + " GB");
        Console.WriteLine("Capacidade total: " + (Convert.ToDouble(ld["Size"]) / 1024 / 1024 / 1024) + " GB");
    }

    searcher = new ManagementObjectSearcher("select * from Win32_Processor");

    Console.WriteLine("\nProcessador----------------------------");
    foreach (var processor in searcher.Get())
    {
        Console.WriteLine("Processador: " + processor["Name"]);
        Console.WriteLine("Total de núcleos: " + processor["NumberOfCores"]);
        Console.WriteLine("Velocidade: " + processor["MaxClockSpeed"] + " MHz");
    }

    searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem");

    Console.WriteLine("\nMemória RAM----------------------------");
    foreach (var ram in searcher.Get())
    {
        Console.WriteLine("Memória RAM: " + (Convert.ToDouble(ram["TotalPhysicalMemory"]) / 1024 / 1024));
    }

    searcher = new ManagementObjectSearcher("select * from Win32_VideoController");

    Console.WriteLine("\nPlaca de vídeo-------------------------");
    foreach (var pv in searcher.Get())
    {
        Console.WriteLine("Placa de vídeo: " + pv["Name"]);
        Console.WriteLine("Memória de vídeo: " + (Convert.ToInt64(pv["AdapterRAM"]) / 1024 / 1024));
        Console.WriteLine("Resolução atual: " + pv["CurrentHorizontalResolution"] + "x" + pv["CurrentVerticalResolution"]);
        Console.WriteLine("Driver version: " + pv["DriverVersion"]);
        Console.WriteLine("Status: " + pv["Status"]);
    }

}
else
{
    Console.WriteLine("Este código só é suportado no Windows.");
}






