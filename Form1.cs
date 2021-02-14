using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;
using System.Runtime.InteropServices;
using YandexDisk.Client.Protocol;

namespace FileSender
{
	public partial class Form1 : Form
	{
		private string _path;
		private string _matchPattern;

		public string Path
		{
			get => _path;
			set => _path = value;
		}

		public string MatchPAttern
		{
			get => _matchPattern;
			set => _matchPattern = value;
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
				label1.Text += string.Join(Environment.NewLine, paths) + Environment.NewLine;
			}
			RecordPaths();
		}

		void RecordPaths()
		{
			try
			{
				if (Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\FileSender"))
				{
					FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\FileSender\TempReadedFileOfPath.txt", FileMode.OpenOrCreate);
					StreamWriter stream = new StreamWriter(file);
					Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\FileSender\TempReadedFileOfPath.txt";
					stream.WriteLine(label1.Text);
					stream.Close();
					file.Close();
				}
				else if (Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\FileSender"))
				{
					FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\FileSender\TempReadedFileOfPath.txt", FileMode.OpenOrCreate);
					StreamWriter stream = new StreamWriter(file);
					Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\FileSender\TempReadedFileOfPath.txt";
					stream.WriteLine(label1.Text);
					stream.Close();
					file.Close();
				}
				else
				{
					FileStream file = new FileStream($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\source\repos\FileSender\TempReadedFileOfPath.txt", FileMode.OpenOrCreate);
					StreamWriter stream = new StreamWriter(file);
					Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\source\repos\FileSender\TempReadedFileOfPath.txt";
					stream.WriteLine(label1.Text);
					stream.Close();
					file.Close();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Возникла ошибка. Поместите директорию с программой на рабочий стол или в стандартный путь репозитория");
			}
		}


		private void button2_Click(object sender, EventArgs e)
		{
			UploadSample();
		}


		async void UploadSample()
		{
			int countFiles;
			string oauthToken = "AgAAAAA73AsNAAbb-2RXKmyTy0OjuGEcU7nvJHA";
			IDiskApi diskApi = new DiskHttpApi(oauthToken);

			
			try
			{
				using (StreamReader readedPaths = new StreamReader(Path))
				{
					string[] arrayPaths = File.ReadAllLines(Path);
					countFiles = arrayPaths.Length-1;
					progressBar1.Maximum = countFiles;

					foreach (string item in arrayPaths)
					{
						Regex regex = new Regex(
							@"[^\\]*$",
							RegexOptions.IgnoreCase
							| RegexOptions.CultureInvariant
							| RegexOptions.IgnorePatternWhitespace
							| RegexOptions.Compiled
						);
						MatchCollection matches = regex.Matches(item);

						foreach (var match in matches)
						{
							await Task.Run(() =>
							{
								diskApi.Files.UploadFileAsync(path: match.ToString(),
									overwrite: false,
									localFile: item,
									cancellationToken: CancellationToken.None);
							});
						}
					}

					for (int i = countFiles; i > 0; i--)
					{
						label4.Text += arrayPaths[i-1] + Environment.NewLine;
						progressBar1.Value++;
						await Task.Delay(100);
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Возникла ошибка. \n" +
					"Закройте программу, затем откройте, перенесите файлы в форму и вновь попытайтесь отправить файлы.");
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (Path != null)
				{
					File.Delete(Path);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Что-то пошло не так.");
			}
		}
	}
}