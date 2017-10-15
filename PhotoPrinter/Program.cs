using System;
using System.Diagnostics;

namespace PhotoPrinter
{
	class MainClass
	{
		const string sourceDir="/home/pi/share/toPhoto";
		const string destDir="/home/pi/share/toPhoto/ready";
		const string cmdPrint="lp -d Canon_CP800 #FILE#";

		public static void Main (string[] args)
		{
			System.IO.FileInfo info;
			//Dies ist ein erster Test
			Console.WriteLine ("Hello World2!");

			foreach (string file in System.IO.Directory.GetFiles(sourceDir,"*.jpg")) {
				Console.WriteLine ("File {0}", file);
				info = new System.IO.FileInfo (file);

				//System.Diagnostics.Process.Start(cmdPrint.Replace("#FILE#",file));

				Process proc = new System.Diagnostics.Process();
				proc.StartInfo.FileName = "/bin/bash";
				proc.StartInfo.Arguments = cmdPrint.Replace("#FILE#",file);
				proc.StartInfo.UseShellExecute = false; 
				proc.StartInfo.RedirectStandardOutput = true;
				proc.Start();

				//nach dem Drucker Dateien verschieben
				Console.WriteLine (destDir + "/" + info.Name);
				System.IO.File.Move (file, destDir + "/" + info.Name);
			}

			Console.ReadKey ();
		}
	}
}
