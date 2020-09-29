using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace Test
{
    public partial class Form1 : Form
    {

        private string path;
        
        public Form1()
        {
            InitializeComponent();
            path = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result ==DialogResult.OK)
                    textBox1.Text = dialog.SelectedPath;
                     path= dialog.SelectedPath;
                string[] files = Directory.GetFiles(dialog.SelectedPath);
            }
        }

        
        
        //create treeView with selected folder path
        public void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));

        }

        //create node in treeView
        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach(var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            foreach(var file in directoryInfo.GetFiles())
            {
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            }

            return directoryNode;
        }

        //click on show folders
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ListDirectory(treeView1, textBox1.Text.ToString());
            }
        }

        //checksum with md5
        public static string CreateDirectoryMd5(string srcPath)
        {
            var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();

            using (var md5 = MD5.Create())
            {
                foreach (var filePath in filePaths)
                {
                    // hash path
                    byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
                    md5.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                    // hash contents
                    byte[] contentBytes = File.ReadAllBytes(filePath);

                    md5.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }

                //Handles empty filePaths case
                md5.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
            }
        }

        //checksum with sha1 
        public static string CreateDirectorySha1(string srcPath)
        {
            var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();

            using (var sha1 = SHA1.Create())
            {
                foreach (var filePath in filePaths)
                {
                    // hash path
                    byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
                    sha1.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                    // hash contents
                    byte[] contentBytes = File.ReadAllBytes(filePath);

                    sha1.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }

                //Handles empty filePaths case
                sha1.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(sha1.Hash).Replace("-", "").ToLower();
            }
        }

        //checksum with sha256
        public static string CreateDirectorySha256(string srcPath)
        {
            var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();

            using (var sha256 = SHA256.Create())
            {
                foreach (var filePath in filePaths)
                {
                    // hash path
                    byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
                    sha256.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                    // hash contents
                    byte[] contentBytes = File.ReadAllBytes(filePath);

                    sha256.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }

                //Handles empty filePaths case
                sha256.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(sha256.Hash).Replace("-", "").ToLower();
            }
        }

        //checksum with sha384
        public static string CreateDirectorySha384(string srcPath)
        {
            var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();

            using (var sha384 = SHA384.Create())
            {
                foreach (var filePath in filePaths)
                {
                    // hash path
                    byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
                    sha384.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                    // hash contents
                    byte[] contentBytes = File.ReadAllBytes(filePath);

                    sha384.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }

                //Handles empty filePaths case
                sha384.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(sha384.Hash).Replace("-", "").ToLower();
            }
        }

        //checksum with sha512
        public static string CreateDirectorySha512(string srcPath)
        {
            var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();

            using (var sha512 = SHA512.Create())
            {
                foreach (var filePath in filePaths)
                {
                    // hash path
                    byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
                    sha512.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                    // hash contents
                    byte[] contentBytes = File.ReadAllBytes(filePath);

                    sha512.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }

                //Handles empty filePaths case
                sha512.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(sha512.Hash).Replace("-", "").ToLower();
            }
        }

        //show checksum on click(button:Show Checksums)
        //write in textBoxes checksums for checked algorithm
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                string res = CreateDirectoryMd5(path);
                textBox2.Text = res.ToString();
            }
            if (checkBox2.Checked)
            {
                string res = CreateDirectorySha1(path);
                textBox3.Text = res.ToString();
            }
            if (checkBox3.Checked)
            {
                string res = CreateDirectorySha256(path);
                textBox4.Text = res.ToString();
            }
            if (checkBox4.Checked)
            {
                string res = CreateDirectorySha384(path);
                textBox5.Text = res.ToString();
            }
            if (checkBox5.Checked)
            {
                string res = CreateDirectorySha512(path);
                textBox6.Text = res.ToString();
            }
        }


        //click on treeView node(if file attribute exist get it, else throw excetion)
        //on click in messagebox show information of file
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            string fileName = "";
           
            

            fileName = treeView1.SelectedNode.Text;
            

            
            long sizeFile=0; 

            
            char[] getE = path.ToArray();
            char oz = getE.ElementAt(2);
            string res = path +oz+ treeView1.SelectedNode.Text;
            FileInfo fileInfo2 = new FileInfo(res);

            //if we check the file
            if (File.Exists(res))
            {
                sizeFile = fileInfo2.Length;
            }
            else//folder and other
            {
                MessageBox.Show("File not found!");
            }
            
            DateTime createdDate= File.GetCreationTime(res);

            //if attributes exist
            FileAttributes describe = File.GetAttributes(res);
            
           
            MessageBox.Show("Name: "+fileName+ "\n" +"Size: " + sizeFile.ToString()+"\n"+"Date: "+createdDate.ToString()+"\n"+"Describe: "+describe.ToString());
        }

        
    }
}
