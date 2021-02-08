﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;

namespace FileSender
{
	public partial class Form1 : Form
	{
		private string _path;

		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}


		public Form1()
		{
			InitializeComponent();
		}



		void panel1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void panel1_DragDrop(object sender, DragEventArgs e)
		{

			string path;
			if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\source\repos\FileSender\TempReadedFileOfPath.txt"))
			{
				FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\source\repos\FileSender\TempReadedFileOfPath.txt", FileMode.OpenOrCreate);			
			}
			else if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\source\repos\FileSender\TempReadedFileOfPath.txt"))
			{
				FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\source\repos\FileSender\TempReadedFileOfPath.txt", FileMode.OpenOrCreate);
			}
			else
			{
				FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\source\repos\FileSender\TempReadedFileOfPath.txt", FileMode.OpenOrCreate);
			}
					
			StreamWriter stream = new StreamWriter("");

			
			List<string> paths = new List<string>();
			foreach (string obj in (e.Data.GetData(DataFormats.FileDrop) as string[]))
			{
				if (Directory.Exists(obj))
				{
					paths.AddRange(Directory.GetFiles(obj, "*.*", SearchOption.AllDirectories));
				}
				else
				{
					paths.Add(obj);
				}
				label1.Text += string.Join(Environment.NewLine, paths) + " ";



				Regex regex = new Regex(@"\r\n", RegexOptions.Multiline);
				MatchCollection matches = regex.Matches(label1.Text);
				if (matches.Count > 0)
				{
					foreach (var match in matches)
					{

						//Path = string.Join(Environment.NewLine, paths) + " ";
						string pattern = @"\r\n";
						string target = " ";
						Regex regexReplacement = new Regex(pattern);
						Path = regexReplacement.Replace(label1.Text, target);



					}
				}


			}

		}

			

		private void button2_Click(object sender, EventArgs e)
		{
			ReadDirectory();

		}



		void ReadDirectory()
		{
			string path = @"C:\Users\gololobovVV\Desktop\папка";

			//foreach (string dir in Directory.GetDirectories(path))
			//{
			foreach (string file in Directory.GetFiles(path))
			{
				label3.Text += file + "\n";

				File.ReadAllLines(label3.Text);

			}
			//}

		}


		async Task UploadSample()
		{






			//You should have oauth token from Yandex Passport.
			//See https://tech.yandex.ru/oauth/
			string oauthToken = "AgAAAAA73AsNAAbb-2RXKmyTy0OjuGEcU7nvJHA";

			// Create a client instance
			IDiskApi diskApi = new DiskHttpApi(oauthToken);

			//Upload file from local
			await diskApi.Files.UploadFileAsync(path: $@"123.txt",
				overwrite: false,
				localFile: @"C:\Users\gololobovVV\Desktop\папка\123.txt",
				cancellationToken: CancellationToken.None);
		}



	}
}