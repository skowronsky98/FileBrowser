using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class Form1 : Form
    {
        List<string> listFiles = new List<string>();
        List<string> listDirectories = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            listDirectories.Clear();
            listView.Items.Clear();

            
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if(fbd.ShowDialog() == DialogResult.OK) 
                {
                    txtPath.Text = fbd.SelectedPath;
                   
                    
                        foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                        {
                            imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                            FileInfo fi = new FileInfo(item);
                            listFiles.Add(fi.FullName);
                            listView.Items.Add(fi.Name, imageList.Images.Count - 1);


                        }

                        foreach (string item in Directory.GetDirectories(fbd.SelectedPath))
                        {
                            DirectoryInfo di = new DirectoryInfo(item);
                            listFiles.Add(di.FullName);
                            listView.Items.Add(di.Name, imageList.Images.Count - 1);


                        }

                    if (listFiles.Count == 0)
                        { 
                            MessageBox.Show("No files in this directory");
                        }
                    
                }
                
                
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        { 
          
            if (listView.FocusedItem != null)
            {
                Process.Start(listFiles[listView.FocusedItem.Index]);
                

            }

        } 
    }
}
