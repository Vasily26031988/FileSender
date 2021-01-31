using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSender
{
	public partial class Form1 : Form
	{
		
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
		}

		
		private void button2_Click(object sender, EventArgs e)
		{			
			
			
			string [] writePath = new string[] { };
			
		}
	}
}
