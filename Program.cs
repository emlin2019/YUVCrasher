// Decompiled with JetBrains decompiler
// Type: YUVCrasher.Program
// Assembly: YUVCrasher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6216E6B9-C7A1-4996-B1E3-D99BFA1C30C2
// Assembly location: C:\Users\koray\Downloads\Compressed\YUVCrasher-v101\YUVCrasher.exe

using System;
using System.Diagnostics;
using System.IO;

namespace YUVCrasher
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      try
      {
        Console.Title = "YUVCrasher | Made by Emlin#0505";
        if (args.Length < 1)
        {
          Console.WriteLine("Usage: " + Process.GetCurrentProcess().MainModule.FileName + " *videofile*");
          Console.ReadKey();
        }
        else
        {
          File.WriteAllText("join.txt", "file '" + args[0] + "'\nfile sample.bin");
          Process process = new Process();
          process.StartInfo.UseShellExecute = false;
          process.StartInfo.RedirectStandardOutput = true;
          process.StartInfo.FileName = "ffmpeg.exe";
          process.StartInfo.Arguments = " -y -f concat -safe 0 -i join.txt -codec copy output.mp4";
          process.Start();
          Console.WriteLine(process.StandardOutput.ReadToEnd());
          process.WaitForExit();
          File.Delete("join.txt");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
        Console.ReadKey();
      }
    }
  }
}
