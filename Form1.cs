using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
			get => _path;
			set => _path = value;
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

				label1.Text += $@"{string.Join("\n\r", paths)} ";
				Path = paths.ToString();
				//Path = label1.Text;
				//Path = string.Join(Environment.NewLine, paths) + Environment.NewLine; 
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{

			StreamReader file = new StreamReader(Path, Encoding.Default);
			string str = file.ReadToEnd();
			string[] readPaths = File.ReadAllLines(Path, Encoding.Default);


			

		}

		async Task UploadSample()
		{
			//You should have oauth token from Yandex Passport.
			//See https://tech.yandex.ru/oauth/
			string oauthToken = "<token hear>";

			// Create a client instance
			IDiskApi diskApi = new DiskHttpApi(oauthToken);

			//Upload file from local
			await diskApi.Files.UploadFileAsync(path: "/foo/myfile.txt",
				overwrite: false,
				localFile: @"C:\myfile.txt",
				cancellationToken: CancellationToken.None);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
